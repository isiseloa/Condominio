using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Util;
using Domain.Model;

namespace Web.Pages
{
    public partial class AnalisarOcorrencia : PageBase
    {
        /// <summary>
        /// evento disparado no load da página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //verifica se é o inicio da página ou um post
            if (!IsPostBack)
            {
                //verifica se existe o parâmetro na querystring
                if (!string.IsNullOrEmpty(Request.QueryString["id"]) && Utilities.IsNumber(Request.QueryString["id"]))
                {
                    ViewState["id"] = Request.QueryString["id"];

                    //consulta a ocorrência de acordo com o id passado na url
                    Ocorrencia ocorrencia = Ocorrencia.FindByPrimaryKey(int.Parse(Request.QueryString["id"]));

                    //preenche os campos na página
                    txtUsuario.Text = ocorrencia.Usuario.ToString();
                    txtTipo.Text = ocorrencia.TipoOcorrencia;
                    txtDescricao.Text = ocorrencia.Detalhes;
                    ddlStatus.SelectedValue = ((int)ocorrencia.Status).ToString();

                }
            }
        }

        /// <summary>
        /// evento disparado pelo botão atualizar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            //consulta a ocorrencia
            Ocorrencia ocorrencia = Ocorrencia.FindByPrimaryKey(int.Parse(ViewState["id"].ToString()));
            //atribui o novo status
            ocorrencia.Status = (Ocorrencia.StatusOcorrencia)Enum.Parse(typeof(Ocorrencia.StatusOcorrencia), ddlStatus.SelectedValue);
            //atualiza a ocorrencia e exibe a mensagem de sucesso
            ocorrencia.UpdateAndFlush();
            lblMensagem.Text = "Ocorrência atualizada com sucesso";
        }

        /// <summary>
        /// evento disparado pelo botão enviar mensagem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEnviarMensagem_Click(object sender, EventArgs e)
        {
            //atribui a mensagem digitada pelo usuário ao template da mensagem
            Domain.Model.Mensagem mensagem = new Domain.Model.Mensagem();
            mensagem.Usuario = base.UsuarioLogado.ToString();
            mensagem.Detalhe = txtMensagem.Text;
            mensagem.CreateAndFlush();

            //busca a ocorrencia
            Ocorrencia ocorrencia = Ocorrencia.FindByPrimaryKey(int.Parse(ViewState["id"].ToString()));

            //cria a mensagem
            MensagensDosUsuarios m = new MensagensDosUsuarios();
            //atribui o template
            m.Mensagem = mensagem;
            //atribui o usuário da ocorrencia
            m.Usuario = ocorrencia.Usuario;
            //envia a mensagem
            m.CreateAndFlush();
            //exibe a mensagem de sucesso
            base.ExibirMensagemSucesso(Funcionalidade.Mensagem, Operacao.Inclusao);
        }
    }
}