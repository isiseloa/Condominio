using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Model;
using Domain.Util.Security;
using System.Collections;

namespace Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// tenta localizar um registro de usuário ativo de acordo com o nome de usuário e senha informados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            var usuario = (from u in Usuario.Todos where u.NomeUsuario == TxtUsuario.Text.Trim().ToLower() && u.Senha == Criptografia.EncriptMD5(TxtSenha.Text.Trim()) && u.StatusDoUsuario == Usuario.Status.Ativo select u).FirstOrDefault();

            //caso usuário seja localizado adiciona o objeto na sessão
            if (usuario != null)
            {
                Session.Add("USER", usuario);
                Response.Redirect("Pages/Default.aspx");
            }
            else
            {
                lblMensagem.Text = "Usuário ou senha inválidos";
            }
        }
    }
}