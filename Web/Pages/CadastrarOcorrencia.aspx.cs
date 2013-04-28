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
    public partial class CadastrarOcorrencia : PageBase
    {
        /// <summary>
        /// load da página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //atribui o nome do usuario logado no campo nome da página
            txtUsuario.Text = base.UsuarioLogado.ToString();
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
                //cria o objeto ocorrência
                Ocorrencia ocorrencia = new Ocorrencia();

                //atribui os dados da página no objeto
                ocorrencia.Usuario = base.UsuarioLogado;
                ocorrencia.TipoOcorrencia = ddlTipoOcorencia.SelectedItem.Text;
                ocorrencia.Detalhes = txtDetalhes.Text;
                ocorrencia.Status = Ocorrencia.StatusOcorrencia.Aberta;
                //salva a ocorrencia no banco
                ocorrencia.SaveAndFlush();
            }
            catch (Exception ex)
            {
                //grava a mensagem de erro no arquivo de log
                Logger.Error(ex.Message);
                base.ExibirMensagemErro();
            }
            base.ExibirMensagemSucesso(Funcionalidade.Ocorrencia, Operacao.Inclusao);
        }
    }
}