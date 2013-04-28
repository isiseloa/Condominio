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
    public partial class ConsultarFuncionario : PageBase
    {
        /// <summary>
        /// evento onload da página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlMensagem.EsconderMensagem();
            //verifica se a página está sendo executada pela primeira vez
            if (!IsPostBack)
            {
                //verifica se o usuário não tem perfil de administrador e redireciona para a página inicial
                if (base.UsuarioLogado.TipoDoUsuario != Usuario.TipoUsuario.AdministradorCondominio)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    btnPesquisar_Click(null, null);
                }
            }
        }


        /// <summary>
        /// eventov disparado pelo botão pesquisar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                //efetua a lista de funcionarios
                var lista = (from f in Funcionario.Todos where f.Nome.Contains(txtPesquisa.Text.Trim()) select f).ToList();

                //se a lista contém dados, mostra os dados na grid
                if (lista != null && lista.Count > 0)
                {
                    grdFuncionarios.DataSource = lista;
                    grdFuncionarios.DataBind();
                    divConteudo.Visible = true;
                }
                else
                {
                    divConteudo.Visible = false;
                }
                
            }
            catch (Exception ex)
            {
                //grava a mensagem de erro no arquivo de log
                Logger.Error(ex.Message);
                pnlMensagem.ExibirMensagem("Ocorreu um erro no sistema ao pesquisar funcionários");
            }
        }
    }
}