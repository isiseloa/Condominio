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
    public partial class ReservarRecurso : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //atribui o nome do usuário logado no campo usuário na página
            txtNome.Text = base.UsuarioLogado.ToString();
        }

        /// <summary>
        /// evento do botão salvar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //atribui os dados da página para o objeto de agendamento
                AgendamentoRecurso agendamento = new AgendamentoRecurso();
                agendamento.Data = DateTime.Parse(ddlData.SelectedValue);
                agendamento.Recurso = ddlRecurso.SelectedValue;
                agendamento.Usuario = base.UsuarioLogado;
                //salva o registro no banco
                agendamento.SaveAndFlush();
            }

            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                base.ExibirMensagemErro();
            }
            base.ExibirMensagemSucesso(Funcionalidade.Reserva, Operacao.Inclusao);
        }

        /// <summary>
        /// efetua a pesquisa de reservas enquanto a data seja maior que hoje e menor que daqui a 2 meses
        /// </summary>
        /// <param name="recurso"></param>
        /// <returns></returns>
        private List<AgendamentoRecurso> ListarReservas(string recurso)
        {
            return (from a in AgendamentoRecurso.Todos where a.Recurso == recurso && a.Data > DateTime.Today && a.Data <= DateTime.Today.AddDays(63) select a).ToList();
        }

        /// <summary>
        /// evento disparado pelo combobox de recurso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlRecurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            //limpa a lista de datas disponiveis
            ddlData.Items.Clear();
            if (ddlRecurso.SelectedIndex > 0)
            {
                //obtem a lista de reservas de determinado recurso
                var lista = ListarReservas(ddlRecurso.SelectedValue);
                DateTime hoje = DateTime.Today;
                //adiciona todos os dias de hoje a até 2 meses adiante
                for (int i = 1; i < 63; i++)
                {
                    ddlData.Items.Add(hoje.AddDays(i).ToShortDateString());
                }
                //remove as datas que ja estiverem reservadas
                foreach (var item in lista)
                {
                    ddlData.Items.Remove(item.Data.ToShortDateString());
                }
            }
        }
    }
}