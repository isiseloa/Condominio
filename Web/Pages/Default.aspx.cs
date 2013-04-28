using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Domain.Model;
using Domain.Util.Diagnostics;

namespace Web
{
    public partial class Default : PageBase
    {
        /// <summary>
        /// evento onload da página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //verifica se a página está sendo executada pela primeira vez
            if (!IsPostBack)
            {
                //exibe o nome do usuário no alto da página
                pnlMensagem.Titulo = string.Format("Bem Vindo {0}", base.UsuarioLogado.ToString());
                //pesquisa mensagens dos usuarios
                PesquisarMensagens();
                //caso o usuario seja administrador do condominio, pesquisa as ocorrencias
                if (UsuarioLogado.TipoDoUsuario == Usuario.TipoUsuario.AdministradorCondominio)
                {
                    imgFundo.Visible = false;
                    PesquisarOcorrencias();
                }
                else
                {
                    //se não for administrador, exibe uma imagem de decoração
                    imgFundo.Visible = true;
                    lblOcorrencias.Visible = false;
                    divOcorrencias.Visible = false;
                }
            }

        }

        /// <summary>
        /// evento disparado pelo link na grid de mensagens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //exclui a mensagem selecionada
                MensagensDosUsuarios.Delete(int.Parse(((LinkButton)sender).CommandArgument));
                PesquisarMensagens();
            }
            catch (Exception ex)
            {
                //grava a mensagem de erro no arquivo de log
                Logger.Error(ex.Message);
                pnlMensagem.ExibirMensagem("Occoreu um erro inesperado no sistema");
            }
        }

        /// <summary>
        /// efetua a pesquisa de mensagens
        /// </summary>
        private void PesquisarMensagens()
        {            
            //efetua a pesquisa de mensagens do usuário            
            var lista = (from m in MensagensDosUsuarios.Todos
                         where m.Usuario.Id == UsuarioLogado.Id
                         select new { m.Mensagem.Usuario, m.Mensagem.Detalhe, m.Id }).ToList();

            //atribui a lista de mensagens na grid 
            if (lista != null && lista.Count > 0)
            {
                grdMensagens.DataSource = lista;
                grdMensagens.DataBind();
                lblMensagens.Visible = true;
            }
            else
            {
                lblMensagens.Visible = false;
                divMensagens.InnerText = "Não há mensagens para visualizar";
            }
        }

        /// <summary>
        /// efetua a pesquisa de ocorrencias
        /// </summary>
        private void PesquisarOcorrencias()
        {
            //consulta as ocorrencias com status diferente de resolvida
            var lista = (from o in Ocorrencia.Todos
                         where o.Status != Ocorrencia.StatusOcorrencia.Resolvida
                         select o).ToList();
            //atribui a lista na grid
            if (lista != null && lista.Count > 0)
            {
                grdOcorrencia.DataSource = lista;
                grdOcorrencia.DataBind();
                lblOcorrencias.Visible = true;
            }
            else
            {
                lblOcorrencias.Visible = false;
                divOcorrencias.InnerText = "Não há ocorrências para visualizar";
            }
        }

        /// <summary>
        /// evento do link analisar na grid de ocorrencias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkAnalisar_Click(object sender, EventArgs e)
        {
            //redireciona para a página de análise de ocorrencias
            Response.Redirect("AnalisarOcorrencia.aspx?id=" + ((LinkButton)sender).CommandArgument);
        }
    }
}