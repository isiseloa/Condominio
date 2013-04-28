using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Model;
using Domain.Util.Diagnostics;

namespace Web.Pages
{
    public partial class Administracao : PageBase
    {
        /// <summary>
        /// load da página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //verifica se o usuário é diferente de administrador. se for, redireciona para a página default
            if (base.UsuarioLogado.TipoDoUsuario != Usuario.TipoUsuario.AdministradorCondominio)
            {
                Response.Redirect("Default.aspx");
            }
            try
            {
                //se for o carregamento inicial da página, pesquisa as despesas, os funcionarios e cria uma
                //lista no viewstate da página
                if (!IsPostBack)
                {
                    PesquisarDespesas();
                    PesquisarFuncionario();
                    ViewState["funcionarios"] = new List<int>();
                }
            }
            catch (Exception ex)
            {
                //grava o erro no arquivo de texto
                Logger.Error(ex.Message);
                pnlMensagem.ExibirMensagem("ocorreu um erro inesperado no sistema");
            }
        }

        /// <summary>
        /// evento de click do link excluir na grid de despesas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //exclui a despesa clicada
                Despesas.Delete(int.Parse(((LinkButton)sender).CommandArgument));
                //refaz a consulta de despesas
                PesquisarDespesas();
            }
            catch (Exception ex)
            {
                //grava o erro em um arquivo de log
                Logger.Error(ex.Message);
                //exibe uma página de erro
                pnlMensagem.ExibirMensagem("Occoreu um erro inesperado no sistema");
            }
        }

        /// <summary>
        /// Efetua a pesquisa de Despesas
        /// </summary>
        private void PesquisarDespesas()
        {
            //consulta as despesas do mes atual, ordenando por data e atribui a lista na grid
            grdDespesas.DataSource = (from d in Despesas.Todos
                                      where d.Data.Month == DateTime.Today.Month
                                      orderby d.Data
                                      select new { d.Descricao, d.Valor, d.Id }).ToList();

            //gera o html na página
            grdDespesas.DataBind();
            btnGerarBoleto.Visible = false;
            lblTotal.Text = string.Empty;
            lblTotalPorUnidade.Text = string.Empty;
        }

        /// <summary>
        /// efetua a consulta de funcionários
        /// </summary>
        private void PesquisarFuncionario()
        {
            //efetua a pesquisa de funcionários, trazendo os que tem salário vigente e atribui a lista na grid
            grdFuncionario.DataSource = (from f in Funcionario.Todos
                                         where (f.Salarios.Where(s => s.Vigente).Count() > 0)
                                         select f).ToList();
            //gera o html na página
            grdFuncionario.DataBind();
        }

        /// <summary>
        /// evento disparado pelo checkbox da grid de funcionários
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //obtem a lista de funcionários selecionados
                List<int> lista = (List<int>)ViewState["funcionarios"];
                //obtem qual a linha da grid que foi selecionada
                int id = int.Parse(((GridViewRow)((CheckBox)sender).Parent.Parent).Cells[3].Text);

                //se o checkbox não foi selecionado, remove o ID da lista
                if (!((CheckBox)sender).Checked)
                {
                    if (lista.Contains(id))
                    {
                        lista.Remove(id);
                        ViewState["funcionarios"] = lista;
                    }
                }
                //se o checkbox foi selecionado, adiciona o ID da lista
                else
                {
                    if (!lista.Contains(id))
                    {
                        lista.Add(id);
                        ViewState["funcionarios"] = lista;
                    }
                }
            }
            catch (Exception ex)
            {
                //grava a mensagem de erro em um arquivo 
                Logger.Error(ex.Message);
                pnlMensagem.ExibirMensagem("ocorreu um erro inesperado no sistema");
            }
        }

        /// <summary>
        /// evento disparado pelo botão converter funcionario em despesa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConverter_Click(object sender, EventArgs e)
        {
            try
            {
                //obtem a lista de funcionarios selecionados no grid
                List<int> lista = (List<int>)ViewState["funcionarios"];

                Funcionario funcionario;
                Despesas despesa;

                //para cada funcionario, gera um registro de despesa 
                //considerando o salário como o valor da despesa
                foreach (int item in lista)
                {
                    funcionario = Funcionario.FindByPrimaryKey(item);
                    despesa = new Despesas();
                    despesa.Descricao = string.Format("Salário do funcionário {0} - {1}", funcionario.Nome, DateTime.Now.ToString("MM/yyyy"));
                    despesa.Valor = funcionario.SalarioVigente.Valor;
                    despesa.Data = DateTime.Today;
                    despesa.CreateAndFlush();
                }
                //refaz a consulta com as novas despesas cadastradas
                PesquisarDespesas();
            }
            catch (Exception ex)
            {
                //grava a mensagemd e erro em um arquivo de texto
                Logger.Error(ex.Message);
                pnlMensagem.ExibirMensagem("ocorreu um erro inesperado no sistema");
            }
        }

        /// <summary>
        /// evento disparado pelo botão calcular
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                //faz a consulta do total de despesas do mês
                decimal total = (from d in Despesas.Todos
                                 where d.Data.Month == DateTime.Today.Month
                                 select d.Valor).Sum();

                if (total > 0)
                {
                    lblTotal.Text = string.Format("Valor total das depesas do condomínio: R$ {0}", total.ToString("F2"));

                    //faz a consulta do total de unidades do condomínio
                    int totalUnidades = Unidade.Todos.Count();

                    if (totalUnidades > 0)
                    {
                        //gera o valor da conta de condominio para cada unidade
                        lblTotalPorUnidade.Text = string.Format("Valor do condomínio por unidade: R$ {0}", (total / totalUnidades).ToString("F2"));
                        btnGerarBoleto.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //grava a mensagem de erro em um arquivo de texto
                Logger.Error(ex.Message);
                pnlMensagem.ExibirMensagem("ocorreu um erro inesperado no sistema");
            }
        }

        /// <summary>
        /// evento disparado pelo botão gerar boleto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGerarBoleto_Click(object sender, EventArgs e)
        {
            try
            {
                //faz uma consulto dos ids dos usuários responsáveis pelas unidades
                List<int> responsaveis = (from u in Usuario.Todos where u.StatusDoUsuario == Usuario.Status.Ativo && u.TipoDoUsuario != Usuario.TipoUsuario.UsuarioComum select u.Id).ToList();

                Usuario user;

                //cria o template da mensagem de geração de boleto
                Domain.Model.Mensagem mensagem = new Domain.Model.Mensagem();
                mensagem.Usuario = UsuarioLogado.ToString();
                mensagem.Detalhe = "Olá, o boleto do condomínio ja está disponível no sistema para download e impressão.";
                mensagem.CreateAndFlush();
                MensagensDosUsuarios m;
                //envia a mensagem para cada usuário responsável por uma unidade
                foreach (int item in responsaveis)
                {
                    user = new Usuario();
                    user.Id = item;
                    m = new MensagensDosUsuarios();
                    m.Usuario = user;
                    m.Mensagem = mensagem;
                    m.CreateAndFlush();
                }
            }
            catch (Exception ex)
            {
                //grava a mensagem de erro em um arquivo de texto
                Logger.Error(ex.Message);
                pnlMensagem.ExibirMensagem("ocorreu um erro inesperado no sistema");
            }
            base.ExibirMensagemSucesso(Funcionalidade.Administracao, Operacao.Inclusao);
        }
    }
}