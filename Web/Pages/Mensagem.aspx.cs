using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Util.Diagnostics;

namespace Web.Pages
{
    public partial class Mensagem : PageBase
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
                //verifica se os parametros da url estão preenchidos
                //e determina se a mensagem será de sucesso ou erro
                if (!string.IsNullOrEmpty(Request.QueryString["result"]))
                {
                    Resultado result = (Resultado)Enum.Parse(typeof(Resultado), Request.QueryString["result"]);

                    if (result == Resultado.Erro)
                    {
                        imgMensagem.ImageUrl = "~/Images/Erros.jpg";
                        lblMensagem.Text = "Ocorreu um erro inesperado no sistema";
                    }
                    else
                    {
                        imgMensagem.ImageUrl = "~/Images/Success.jpg";
                        lblMensagem.Text = GerarMensagemSucesso();
                    }
                }
            }
            catch(Exception ex)
            {
                imgMensagem.ImageUrl = "~/Images/Erros.jpg";
                lblMensagem.Text = "Ocorreu um erro inesperado no sistema.";
                Logger.Error(ex.Message);
            }
        }

        /// <summary>
        /// gera a mensagem de sucesso de acordo com a entidade e o tipo de operação
        /// </summary>
        /// <returns></returns>
        private string GerarMensagemSucesso()
        {
            string mensagemPadrao = "Operação realizada com sucesso.";
            if (!string.IsNullOrEmpty(Request.QueryString["func"]) && !string.IsNullOrEmpty(Request.QueryString["op"]))
            {
                Funcionalidade func = (Funcionalidade)Enum.Parse(typeof(Funcionalidade), Request.QueryString["func"]);
                Operacao op = (Operacao)Enum.Parse(typeof(Operacao), Request.QueryString["op"]);

                string mensagem = "{0} {1} com sucesso.";

                if (func == Funcionalidade.AtaDeReuniao)
                {
                    if (op == Operacao.Inclusao)
                    {
                        return string.Format(mensagem, "Ata de reunião",  "salva");
                    }
                    else if (op == Operacao.Alteracao)
                    {
                        return string.Format(mensagem, "Ata de reunião", "alterada");
                    }
                    else if (op == Operacao.Exclusao)
                    {
                        return string.Format(mensagem, "Ata de reunião", "excluída");
                    }
                }
                else if (func == Funcionalidade.Comunicado)
                {
                    if (op == Operacao.Inclusao)
                    {
                        return string.Format(mensagem, "Comunicado", "salvo");
                    }
                    else if (op == Operacao.Alteracao)
                    {
                        return string.Format(mensagem, "Comunicado", "alterado");
                    }
                    else if (op == Operacao.Exclusao)
                    {
                        return string.Format(mensagem, "Comunicado", "excluído");
                    }
                }
                else if (func == Funcionalidade.Despesa)
                {
                    if (op == Operacao.Inclusao)
                    {
                        return string.Format(mensagem, "Despesa", "salva");
                    }
                    else if (op == Operacao.Alteracao)
                    {
                        return string.Format(mensagem, "Despesa", "alterada");
                    }
                    else if (op == Operacao.Exclusao)
                    {
                        return string.Format(mensagem, "Despesa", "excluída");
                    }
                }
                else if (func == Funcionalidade.Funcionario)
                {
                    if (op == Operacao.Inclusao)
                    {
                        return string.Format(mensagem, "Funcionário", "salvo");
                    }
                    else if (op == Operacao.Alteracao)
                    {
                        return string.Format(mensagem, "Funcionário", "alterado");
                    }
                    else if (op == Operacao.Exclusao)
                    {
                        return string.Format(mensagem, "Funcionário", "excluído");
                    }
                }
                else if (func == Funcionalidade.Usuario)
                {
                    if (op == Operacao.Inclusao)
                    {
                        return string.Format(mensagem, "Usuário", "salvo");
                    }
                    else if (op == Operacao.Alteracao)
                    {
                        return string.Format(mensagem, "Usuário", "alterado");
                    }
                    else if (op == Operacao.Exclusao)
                    {
                        return string.Format(mensagem, "Usuário", "excluído");
                    }
                }
                else if (func == Funcionalidade.Unidade)
                {
                    if (op == Operacao.Inclusao)
                    {
                        return string.Format(mensagem, "Unidade", "salva");
                    }
                    if (op == Operacao.Alteracao)
                    {
                        return string.Format(mensagem, "Unidade", "alterada");
                    }
                }
                else if (func == Funcionalidade.Reserva)
                {
                    if (op == Operacao.Inclusao)
                    {
                        return string.Format(mensagem, "Reserva de Recurso", "feita");
                    }
                    if (op == Operacao.Exclusao)
                    {
                        return string.Format(mensagem, "Reserva de Recurso", "cancelada");
                    }
                }
                else if (func == Funcionalidade.Ocorrencia)
                {
                    if (op == Operacao.Inclusao)
                    {
                        return string.Format(mensagem, "Ocorrência", "criada");
                    }                    
                }
                else if (func == Funcionalidade.Mensagem)
                {
                    if (op == Operacao.Inclusao)
                    {
                        return string.Format(mensagem, "Mensagem", "enviada");
                    }
                }
                else if (func == Funcionalidade.Administracao)
                {
                    if (op == Operacao.Inclusao)
                    {
                        return string.Format(mensagem, "Contas", "fechadas");
                    }
                }
            }

            return mensagemPadrao;

        }
    }
}