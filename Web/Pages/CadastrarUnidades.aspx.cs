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
    public partial class CadastrarUnidades : PageBase
    {
        /// <summary>
        /// evento de load da página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //verifica se o usuário tem perfil do tipo administrador. se não
            //tiver, redireciona para a página inicial
            if (base.UsuarioLogado.TipoDoUsuario != Usuario.TipoUsuario.AdministradorCondominio)
            {
                Response.Redirect("Default.aspx");
            }
            //verifica se existe o parâmetro id na url. se tiver, guarda esse id no campo oculto e preenche os campos da pagina
            if (!string.IsNullOrEmpty(Request.QueryString["id"]) && Utilities.IsNumber(Request.QueryString["id"]))
            {
                hddId.Value = Request.QueryString["id"];
                this.preencherCampos();
            }
        }

        /// <summary>
        /// preenche os campos da página com o registro consultado
        /// </summary>
        private void preencherCampos()
        {
            //verifica se o campo oculto de id está preenchido
            if (!string.IsNullOrEmpty(this.hddId.Value))
            {
                //busca a unidade pelo id
                Unidade unidade = Unidade.FindByPrimaryKey(int.Parse(Request.QueryString["id"]));
                //preenche os campos na página
                txtNumero.Text = unidade.Numero;
                txtAndar.Text = unidade.Piso.ToString();
                txtTorre.Text = unidade.Torre;
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
                //verifica se o campo oculto está vazio
                if (string.IsNullOrEmpty(hddId.Value))
                {
                    //cria o objeto unidade e preenche com os campos da página
                    Unidade u = new Unidade();
                    u.Numero = txtNumero.Text.Trim();
                    u.Piso = int.Parse(txtAndar.Text.Trim());
                    u.Torre = txtTorre.Text.Trim();
                    //salva a unidade no banco
                    u.CreateAndFlush();
                }
                else
                {
                    //busca o registro de unidade de acordo com o id guardado no campo oculto
                    Unidade u = Unidade.FindByPrimaryKey(int.Parse(hddId.Value));
                    //preenche o objeto com os campos da página
                    u.Numero = Request.Form["ctl00$ContentPlaceHolder1$txtNumero"];
                    u.Piso = int.Parse(Request.Form["ctl00$ContentPlaceHolder1$txtAndar"]);
                    u.Torre = Request.Form["ctl00$ContentPlaceHolder1$txtTorre"];
                    //atualiza o registro
                    u.UpdateAndFlush();
                }
            }
            catch (Exception ex)
            {
                //salva a mensagem de erro no arquivo de log
                Logger.Error(ex.Message);
                base.ExibirMensagemErro();
            }
            base.ExibirMensagemSucesso(Funcionalidade.Unidade, (string.IsNullOrEmpty(hddId.Value)) ? Operacao.Inclusao : Operacao.Alteracao);
        }
    }
}
