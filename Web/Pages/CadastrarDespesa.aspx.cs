using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Util;
using Domain.Model;
using Domain.Util.Diagnostics;

namespace Web.Pages
{
    public partial class CadastrarDespesa : PageBase
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
            if (UsuarioLogado.TipoDoUsuario != Usuario.TipoUsuario.AdministradorCondominio)
            {
                Response.Redirect("Default.aspx");
            }
        }

        /// <summary>
        /// validação de data válida
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //verifica se a data é válida
            args.IsValid = Utilities.IsValidDate(Request.Form["ctl00$ContentPlaceHolder1$txtData"]);
        }

        /// <summary>
        /// evento disparado pelo botão salvar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            //verifica se os campos da página estão válidos
            if (Page.IsValid)
            {
                try
                {
                    //cria um novo objeto de despesa
                    Despesas despesa = new Despesas();
                    //atribui os dados que estão na página
                    despesa.Descricao = txtDescricao.Text;
                    despesa.Valor = decimal.Parse(txtValor.Text);
                    despesa.Data = DateTime.Parse(txtData.Text);
                    //salva o registro no banco
                    despesa.CreateAndFlush();
                }
                catch (Exception ex)
                {
                    //grava a mensagemd de erro no banco de dados
                    Logger.Error(ex.Message);
                    base.ExibirMensagemErro();
                }
                base.ExibirMensagemSucesso(Funcionalidade.Despesa, Operacao.Inclusao);
            }
        }
    }
}