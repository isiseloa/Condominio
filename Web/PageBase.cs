using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Domain.Model;

namespace Web
{
    /// <summary>
    /// Classe base que deve ser herdada por todas as páginas do site
    /// </summary>
    public class PageBase : Page
    {
        /// <summary>
        /// verifica se existe um usuário logado na sessão. se não existir, redireciona para o login
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if (Session["USER"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            base.OnLoad(e);
        }

        private Usuario usuarioLogado = null;
        /// <summary>
        /// obtem o objeto com os dados do usuário logado
        /// </summary>
        public Usuario UsuarioLogado
        {
            get
            {
                if (usuarioLogado == null)
                    usuarioLogado = (Usuario)Session["USER"];

                return usuarioLogado;
            }
        }

        public enum Funcionalidade
        {
            AtaDeReuniao,
            Comunicado,
            Despesa,
            Funcionario,
            Usuario,
            Unidade,
            Reserva,
            Ocorrencia,
            Mensagem,
            Administracao
        }

        public enum Operacao
        {
            Inclusao,
            Alteracao,
            Exclusao
        }

        public enum Resultado
        {
            Sucesso,
            Erro
        }

        /// <summary>
        /// redireciona para a página de erro
        /// </summary>
        public void ExibirMensagemErro()
        {
            Response.Redirect(string.Format("Mensagem.aspx?result={0}", Resultado.Erro), true);
        }

        /// <summary>
        /// redireciona para a página de sucesso
        /// </summary>
        /// <param name="funcionalidade"></param>
        /// <param name="operacao"></param>
        public void ExibirMensagemSucesso(Funcionalidade funcionalidade, Operacao operacao)
        {
            Response.Redirect(string.Format("~/Pages/Mensagem.aspx?result={0}&func={1}&op={2}", Resultado.Sucesso, funcionalidade, operacao), true);
        }


    }
}