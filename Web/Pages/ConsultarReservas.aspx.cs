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
    public partial class ConsultarReservas : PageBase
    {
        /// <summary>
        /// evento disparado pelo onload da página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //efetua a pesquisa de reservas
                Pesquisar();
            }
            catch (Exception ex)
            {
                //salva o erro em um arquivo de log
                Logger.Error(ex.Message);
                pnlMessagem.ExibirMensagem("Occoreu um erro inesperado no sistema");
            }
        }

        /// <summary>
        /// evento disparado pelo link de cancelar reserva na grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //exclui o registro de reserva selecionado
                AgendamentoRecurso.Delete(int.Parse(((LinkButton)sender).CommandArgument));
                Pesquisar();
            }
            catch (Exception ex)
            {
                //grava a mensagem de erro em um arquivo de log
                Logger.Error(ex.Message);
                pnlMessagem.ExibirMensagem("Occoreu um erro inesperado no sistema");
            }
        }

        /// <summary>
        /// efetua a pesquisa de reservas
        /// </summary>
        private void Pesquisar()
        {
            //consulta os registros de ocorrência cuja a data seja maior que o dia de hoje
            var consulta = (from a in AgendamentoRecurso.Todos where a.Data > DateTime.Today select a);
            if (UsuarioLogado.Unidade!= null)
            {
                //adiciona o filtro por unidade
                consulta = consulta.Where(a => a.Usuario.Unidade.Id == UsuarioLogado.Unidade.Id);
            }

            //atribui a lista pesquisada na grid
            var lista = consulta.ToList();
            if (lista != null && lista.Count > 0)
            {
                grdAgendamentos.DataSource = lista;
                grdAgendamentos.DataBind();
                divConteudo.Visible = true;
            }
            else
            {
                divConteudo.Visible = false;
            }
        }
    }
}