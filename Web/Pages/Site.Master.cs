using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Model;

namespace Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //desabilita links caso usuário não seja administrador
            if (UsuarioLogado.TipoDoUsuario != Usuario.TipoUsuario.AdministradorCondominio)
            {
                LinkUnidades.Enabled = false;
                LinkFuncionarios.Enabled = false;
                LinkDespesas.Enabled = false;
                LinkAdministracao.Enabled = false;
                LinkUnidades.ForeColor = System.Drawing.Color.Gray;
                LinkFuncionarios.ForeColor = System.Drawing.Color.Gray;
                LinkDespesas.ForeColor = System.Drawing.Color.Gray;
                LinkAdministracao.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private Usuario usuarioLogado = null;
        //obtem o usuário logado da sessão
        private Usuario UsuarioLogado
        {
            get
            {
                if (usuarioLogado == null)
                    usuarioLogado = (Usuario)Session["USER"];

                return usuarioLogado;
            }
        }

        protected void Btnsair_Click(object sender, EventArgs e)
        {

            Response.Close();
            
        }

        
    }
}