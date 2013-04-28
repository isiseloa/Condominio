using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Util.Security;
using Domain.Model;
using Domain.Util.Diagnostics;

namespace Web.Pages
{
    public partial class AlterarSenha : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// evento disparado pelo botão salvar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            //verifica so os campos são válidos
            if (Page.IsValid)
            {
                try
                {
                    //atribui a nova senha e atuializa o usuario
                    Usuario usuario = Usuario.FindByPrimaryKey(UsuarioLogado.Id);
                    usuario.Senha = Criptografia.EncriptMD5(txtNovaSenha.Text.Trim());
                    usuario.UpdateAndFlush();
                    UsuarioLogado.Senha = usuario.Senha;
                }
                catch (Exception ex)
                {
                    //grava o erro em uma mensagem de texto
                    Logger.Error(ex.Message);
                    base.ExibirMensagemErro();
                }
                base.ExibirMensagemSucesso(Funcionalidade.Usuario, Operacao.Alteracao);
            }
        }

        /// <summary>
        /// validação de senha atual incorreta
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //verifica se a senha digitada confere com a senha atual do usuario
            args.IsValid = (Criptografia.EncriptMD5(args.Value) == base.UsuarioLogado.Senha);
        }
    }
}