using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Util;
using Domain.Util.Diagnostics;
using Domain.Model;
using Castle.ActiveRecord;

namespace Web.Pages
{
    public partial class CadastrarFuncionario : PageBase
    {
        /// <summary>
        /// evento disparado pelo load da página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                pnlMensagem.EsconderMensagem();
                //verifica se o usuário logado tem perfil de administrador do condominio, se não
                //tiver, redireciona para a página inicial
                if (base.UsuarioLogado.TipoDoUsuario != Usuario.TipoUsuario.AdministradorCondominio)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    //verifica se existe o parâmetro na url
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        //busca o funcionário de acordo com o id na url
                        Funcionario f = Funcionario.FindByPrimaryKey(int.Parse(Request.QueryString["id"]), false);
                        if (f != null)
                        {
                            //preenche os campons na página
                            this.PreencherCampos(f);
                        }
                    }
                    if (Page.IsPostBack)
                    {
                        //campos data preenchidos com javascript precisam ser preenchidos novamente a cada postback
                        txtDataNascimento.Text = Request.Form["ctl00$ContentPlaceHolder1$txtDataNascimento"];
                        txtDataContratacao.Text = Request.Form["ctl00$ContentPlaceHolder1$txtDataContratacao"];
                    }
                  

                }
            }
            catch (Exception ex)
            {
                //grava a mensagem de erro no arquivo de log
                Logger.Error(ex.Message);
                base.ExibirMensagemErro();
            }
        }

        /// <summary>
        /// preenche os campos na página com os valores previamente consultados
        /// </summary>
        /// <param name="funcionario"></param>
        private void PreencherCampos(Funcionario funcionario)
        {
            txtNome.Text = funcionario.Nome;
            txtEndereco.Text = funcionario.Endereco;
            txtCpf.Text = funcionario.CPF;
            txtRG.Text = funcionario.RG;
            txtTelefone.Text = funcionario.Telefone;
            txtDataNascimento.Text = funcionario.DataNascimento.ToShortDateString();
            txtDataContratacao.Text = funcionario.DataAdmissao.ToShortDateString();
            txtCarteiratrabalho.Text = funcionario.NumeroCarteiraTrabalho;
            txtCargo.Text = funcionario.Cargo;
            hddId.Value = funcionario.Id.ToString();
            if (funcionario.SalarioVigente != null)
                txtSalario.Text = funcionario.SalarioVigente.Valor.ToString("#######000.00");
        }

        /// <summary>
        /// evento disparado pelo botão salvar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            //verifica so os campos da página estão válidos
            if (Page.IsValid)
            {
                bool novo = string.IsNullOrEmpty(hddId.Value);
                try
                {
                    if (!novo)
                    {
                        //funcionalidade de editar
                        EditarFuncionario(int.Parse(hddId.Value));
                    }
                    else
                    {
                        //funcionalidade de cadastro de novo registro
                        CadastrarNovoFuncionario();
                    }
                }
                catch (Exception ex)
                {
                    //grava o erro em um arquivo
                    Logger.Error(ex.Message);
                    ExibirMensagemErro();
                }

                ExibirMensagemSucesso(Funcionalidade.Funcionario, (novo) ? Operacao.Inclusao : Operacao.Alteracao);
            }
        }

        /// <summary>
        /// grava um novo registro de funcionário
        /// </summary>
        private void CadastrarNovoFuncionario()
        {
            //abre a transação
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    //atribui os dados da página para o registro de funcionário e salva no banco
                    Funcionario funcionario = new Funcionario();
                    funcionario.Nome = txtNome.Text.Trim();
                    funcionario.Endereco = txtEndereco.Text.Trim();
                    funcionario.CPF = txtCpf.Text.Trim();
                    funcionario.RG = txtRG.Text.Trim();
                    funcionario.Telefone = txtTelefone.Text.Trim();
                    funcionario.DataNascimento = DateTime.Parse(txtDataNascimento.Text.Trim());
                    funcionario.DataAdmissao = DateTime.Parse(txtDataContratacao.Text.Trim());
                    funcionario.NumeroCarteiraTrabalho = txtCarteiratrabalho.Text.Trim();
                    funcionario.Cargo = txtCargo.Text.Trim();
                    funcionario.CreateAndFlush();

                    if (txtSalario.Text.Trim() != string.Empty)
                    {
                        decimal valor = decimal.Parse(txtSalario.Text.Trim());
                        if (valor != 0)
                        {
                            //cria o registro do salário
                            Salario salario = new Salario();
                            salario.InicioVigencia = DateTime.Parse(txtDataContratacao.Text.Trim());
                            salario.Vigente = true;
                            salario.Valor = valor;
                            salario.FuncionarioDoSalario = funcionario;
                            salario.CreateAndFlush();
                        }
                    }
                    //commit da transação
                    trans.VoteCommit();
                }
                catch (Exception ex)
                {
                    //rollback da transação
                    trans.VoteRollBack();
                    //sobe o erro para o método que o chamou, onde será gravado em um arquivo de texto
                    throw ex;
                }
                finally
                {
                    //fecha a transasção
                    trans.Flush();
                }
            }
        }

        /// <summary>
        /// funcionalidade de edição de um registro de funcionario
        /// </summary>
        /// <param name="id"></param>
        private void EditarFuncionario(int id)
        {
            //abre a transação
            using (TransactionScope trans = new TransactionScope())
            {

                try
                {
                    //consulta o funcionário pelo ID
                    Funcionario funcionario = Funcionario.FindByPrimaryKey(id);
                    //atribui os dados que estão na página
                    funcionario.Nome = Request.Form["ctl00$ContentPlaceHolder1$txtNome"]; //txtNome.Text.Trim();
                    funcionario.Endereco = Request.Form["ctl00$ContentPlaceHolder1$txtEndereco"]; //txtEndereco.Text.Trim();
                    funcionario.CPF = Request.Form["ctl00$ContentPlaceHolder1$txtCpf"]; //txtCpf.Text.Trim();
                    funcionario.RG = Request.Form["ctl00$ContentPlaceHolder1$txtRG"]; //txtRG.Text.Trim();
                    funcionario.Telefone = Request.Form["ctl00$ContentPlaceHolder1$txtTelefone"]; //txtTelefone.Text.Trim();
                    funcionario.DataNascimento = DateTime.Parse(Request.Form["ctl00$ContentPlaceHolder1$txtDataNascimento"]);
                    funcionario.DataAdmissao = DateTime.Parse(Request.Form["ctl00$ContentPlaceHolder1$txtDataContratacao"]);
                    funcionario.NumeroCarteiraTrabalho = Request.Form["ctl00$ContentPlaceHolder1$txtCarteiratrabalho"];// txtCarteiratrabalho.Text.Trim();
                    funcionario.Cargo = Request.Form["ctl00$ContentPlaceHolder1$txtCargo"];// txtCargo.Text.Trim();
                    //atualiza o funcionário
                    funcionario.UpdateAndFlush();
                    if (Request.Form["ctl00$ContentPlaceHolder1$txtSalario"].Trim() != string.Empty)
                    {
                        //verifica se tem salário e se houve alteração do valor
                        decimal valor = decimal.Parse(Request.Form["ctl00$ContentPlaceHolder1$txtSalario"]);

                        if (funcionario.SalarioVigente != null)
                        {
                            if (funcionario.SalarioVigente.Valor != valor)
                            {
                                //atribui o valor da salário
                                funcionario.SalarioVigente.FinalVigencia = DateTime.Today;
                                funcionario.SalarioVigente.Vigente = false;
                                //atualiza o registro
                                funcionario.SalarioVigente.UpdateAndFlush();

                                if (valor != 0)
                                {
                                    Salario salario = new Salario();
                                    salario.InicioVigencia = DateTime.Today;
                                    salario.Vigente = true;
                                    salario.Valor = valor;
                                    salario.FuncionarioDoSalario = funcionario;
                                    salario.CreateAndFlush();
                                }
                            }
                        }
                    }
                    else
                    {
                        if (funcionario.SalarioVigente != null)
                        {
                            funcionario.SalarioVigente.FinalVigencia = DateTime.Today;
                            funcionario.SalarioVigente.Vigente = false;
                            funcionario.SalarioVigente.UpdateAndFlush();
                        }
                    }
                    //commit da transação
                    trans.VoteCommit();
                }
                catch (Exception ex)
                {
                    //rollback da transação
                    trans.VoteRollBack();
                    throw ex;
                }
                finally
                {
                    trans.Flush();
                }
            }
        }

        /// <summary>
        /// valida se a data de nascimento é válida
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Utilities.IsValidDate(Request.Form["ctl00$ContentPlaceHolder1$txtDataNascimento"]);
        }

        /// <summary>
        /// valida se a data de contratação é válida
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Utilities.IsValidDate(Request.Form["ctl00$ContentPlaceHolder1$txtDataContratacao"]);
        }
    }
}