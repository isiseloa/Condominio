using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Model;
using Domain.Util.Diagnostics;
using Domain.Util;

namespace Web.Pages
{
    public partial class CadastrarComunicado : PageBase
    {
        /// <summary>
        /// evento disparado pelo load da página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //verifica se o usuario tem perfil de adminstrador do condomínio. se não tiver
            //redireciona para a página inicial
            if (base.UsuarioLogado.TipoDoUsuario != Usuario.TipoUsuario.AdministradorCondominio)
            {
                Response.Redirect("Default.aspx");
            }
        }

        /// <summary>
        /// evento disparado pelo botão salvar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //cria o objeto comunicado
                Comunicado comunicado = new Comunicado();
                //atribui os dados digitados na página
                comunicado.Titulo = txtTitulo.Text;
                comunicado.Texto = Editor1.Content;
                comunicado.Usuario = base.UsuarioLogado;
                //atribui o tipo do registro (Comunicado)
                comunicado.Tipo = Comunicado.TipoRegistro.Comunicado;
                //salva o registro
                comunicado.SaveAndFlush();
            }
            catch (Exception ex)
            {
                //grava a mensagem de erro no arquivo
                Logger.Error(ex.Message);
                base.ExibirMensagemErro();
            }
            base.ExibirMensagemSucesso(Funcionalidade.Comunicado, Operacao.Inclusao);
        }
    }
}