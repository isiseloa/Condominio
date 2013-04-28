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
    public partial class ConsultarAta : PageBase
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
                //esconde o link de cadastro caso o usuário não seja administrador
                linkCadastro.Visible = base.UsuarioLogado.TipoDoUsuario == Usuario.TipoUsuario.AdministradorCondominio;
                if (!Page.IsPostBack)
                {
                    //adiciona valores padrão das datas de pesquisa
                    txtDataFim.Text = DateTime.Now.ToShortDateString();
                    txtDataInicio.Text = DateTime.Now.AddMonths(-1).ToShortDateString();
                    //executa a pesquisa
                    btnPesquisar_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                //salva o registro no banco de dados
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
            //verifica se as datas estão válidas e com intervalos corretos

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
                    //consulta os comunicados (atas)
                    var lista = Comunicado.ObterAtas(dataInicial, dataFinal);
                    //se a lista contém registros, atribui na grid
                    if (lista != null && lista.Count > 0)
                    {
                        grdAtas.DataSource = lista;
                        grdAtas.DataBind();
                        divConteudo.Visible = true;
                    }
                    else
                    {
                        divConteudo.Visible = false;
                    }
                }
            }
        }
    }
}