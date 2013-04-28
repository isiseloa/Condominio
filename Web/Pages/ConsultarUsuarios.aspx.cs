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
    public partial class ConsultarUsuarios : PageBase
    {

        /// <summary>
        /// onload da página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                pnlMensagem.EsconderMensagem();
                //verifica se é a primeira vez que a página é executada
                if (!IsPostBack)
                {
                    //efetua a pesquisa
                    btnPesquisar_Click(sender, e);
                    //esconde os campos caso usuario seja do perfil usuário comum
                    linkCadastrar.Visible = base.UsuarioLogado.TipoDoUsuario != Usuario.TipoUsuario.UsuarioComum;
                    chkSomenteAtivos.Visible = base.UsuarioLogado.TipoDoUsuario == Usuario.TipoUsuario.AdministradorCondominio;
                }
            }
            catch (Exception ex)
            {
                //grava a mensagem de erro no arquivo de log
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
                //verifica se o usuário é administrador e consulta todos os usuários
                if (base.UsuarioLogado.TipoDoUsuario == Usuario.TipoUsuario.AdministradorCondominio)
                {
                    var usuarios = (from u in Usuario.Todos where (u.Nome.Contains(txtPesquisa.Text.Trim()) || u.Sobrenome.Contains(txtPesquisa.Text.Trim())) select u);
                    if (chkSomenteAtivos.Checked)
                        usuarios = usuarios.Where(u => u.StatusDoUsuario == Usuario.Status.Ativo);

                    grdUsuarios.DataSource = usuarios.ToList();
                }
                //se o usuário for resposnsável por alguma unidade, consulta
                //os usuários da sua unidade
                else if (base.UsuarioLogado.TipoDoUsuario == Usuario.TipoUsuario.ResponsavelUnidade)
                {
                    grdUsuarios.DataSource = (from u in Usuario.Todos where (u.Nome.Contains(txtPesquisa.Text.Trim()) || u.Sobrenome.Contains(txtPesquisa.Text.Trim())) && u.Unidade.Id == UsuarioLogado.Unidade.Id && u.StatusDoUsuario == Usuario.Status.Ativo select u).ToList();
                }
                    //se o usuário for do tipo comum, somente seu registro será exibido
                else
                {
                    var lista = new List<Usuario>();
                    lista.Add(base.UsuarioLogado);
                    grdUsuarios.DataSource = lista;
                }

                //gera o html da grid na página
                grdUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                //grava a mensagem de erro no arquivo de log
                Logger.Error(ex.Message);
                pnlMensagem.ExibirMensagem("Ocorreu um erro inesperado no sistema");
            }
        }

        protected void grdUsuarios_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }
    }
}