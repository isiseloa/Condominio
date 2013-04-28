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
    public partial class ConsultarUnidades : PageBase
    {
        /// <summary>
        /// evento onload da página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //caso o usuário não seja administrador, redireciona para a página inicial
            if (base.UsuarioLogado.TipoDoUsuario != Usuario.TipoUsuario.AdministradorCondominio)
            {
                Response.Redirect("Default.aspx");
            }
            try
            {
                //consulta todas as unidades
                var lista = Unidade.FindAll();
                //atribui a lista de unidades na grid
                if (lista != null && lista.Count > 0)
                {
                    grdUnidades.DataSource = lista;
                    //cria o html na página
                    grdUnidades.DataBind();
                    divConteudo.Visible = true;
                }
                else
                {
                    divConteudo.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //gera o arquivo de log com a mensagem de erro
                Logger.Error(ex.Message);
                pnlMensagem.ExibirMensagem("Ocorreu um erro inesperado no sistema");
            }
        }
    }
}