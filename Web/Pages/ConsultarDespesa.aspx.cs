using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Model;
using Domain.Util;
using Domain.Util.Diagnostics;

namespace Web.Pages
{
    public partial class ConsultarDespesa : PageBase
    {
        /// <summary>
        /// evento disparado pelo onload da página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //se o usuário não tiver perfil de administrador do condomínio, redireciona para a página inicial
                if (UsuarioLogado.TipoDoUsuario != Usuario.TipoUsuario.AdministradorCondominio)
                {
                    Response.Redirect("Default.aspx");
                }

                pnlMensagem.EsconderMensagem();
                //verifica se a página está sendo executada pela primeira vez   
                if (!Page.IsPostBack)
                {
                    //adiciona o dia atual
                    txtDataFim.Text = DateTime.Now.ToShortDateString();
                    //adiciona o primeiro dia do mês
                    txtDataInicio.Text = DateTime.Today.AddDays(-1 * (DateTime.Today.Day - 1)).ToShortDateString();
                    //efetua a pesquisa
                    Pesquisar();
                }
            }
            catch (Exception ex)
            {
                //grava o erro em um arquivo de texto
                Logger.Error(ex.Message);
                pnlMensagem.ExibirMensagem("Ocorreu um erro inesperado no sistema");
            }
        }

        /// <summary>
        /// evento disparado pelo botão pesquisar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                Pesquisar();
            }
            catch (Exception ex)
            {
                //grava a mensagem de erro no arquivo de log
                Logger.Error(ex.Message);
                pnlMensagem.ExibirMensagem("Ocorreu um erro inesperado no sistema");
            }

        }

        /// <summary>
        /// valida as datas e efetua a pesquisa
        /// </summary>
        private void Pesquisar()
        {
            try
            {
                if (txtDataInicio.Text.Trim() == string.Empty)
                {
                    pnlMensagem.ExibirMensagem("Preencha a data inicial");
                }
                else if (txtDataFim.Text.Trim() == string.Empty)
                {
                    pnlMensagem.ExibirMensagem("Preencha a data final");
                }
                else if (!Utilities.IsValidDate(txtDataInicio.Text.Trim()))
                {
                    pnlMensagem.ExibirMensagem("Data inicial inválida");
                }
                else if (!Utilities.IsValidDate(txtDataFim.Text.Trim()))
                {
                    pnlMensagem.ExibirMensagem("Data final inválida");
                }
                else
                {
                    DateTime dataInicial = DateTime.Parse(txtDataInicio.Text.Trim());
                    DateTime dataFinal = DateTime.Parse(txtDataFim.Text.Trim());
                    if (dataInicial.Year < 1900 || dataInicial.Year > 2100)
                    {
                        pnlMensagem.ExibirMensagem("Data inicial inválida");
                    }
                    else if (dataFinal.Year < 1900 || dataFinal.Year > 2100)
                    {
                        pnlMensagem.ExibirMensagem("Data final inválida");
                    }
                    else if (dataInicial > dataFinal)
                    {
                        pnlMensagem.ExibirMensagem("A data inicial não pode ser maior que a data final");
                    }
                    else
                    {
                        //faz a pesquisa de despesas de acordo com as datas 
                        var lista = (from d in Despesas.Todos where d.Data.Date >= DateTime.Parse(txtDataInicio.Text) && d.Data.Date <= DateTime.Parse(txtDataFim.Text) select d).ToList();

                        if (lista != null && lista.Count > 0)
                        {
                            grdDespesas.DataSource = lista;
                            grdDespesas.DataBind();
                            divConteudo.Visible = true;
                        }
                        else
                        {
                            divConteudo.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                pnlMensagem.ExibirMensagem("Ocorreu um erro inespererado no sistema");
            }
        }

        /// <summary>
        /// evento disparado pelo lin excluir na grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //exclui a despesa selecionada
                Despesas.Delete(int.Parse(((LinkButton)sender).CommandArgument));
                Pesquisar();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                pnlMensagem.ExibirMensagem("Occoreu um erro inesperado no sistema");
            }
        }
    }
}