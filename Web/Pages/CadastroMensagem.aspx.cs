using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Model;
using Domain.Util.Diagnostics;
using Castle.ActiveRecord;

namespace Web.Pages
{
    public partial class CadastroMensagem : PageBase
    {
        /// <summary>
        /// evento de load da página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //verifica se página está sendo carregada pela primeira vez
            if (!Page.IsPostBack)
            {
                //atribui o usuário logado no campo texto
                txtUsuario.Text = base.UsuarioLogado.ToString();
                //consulta os usuário que estão atribuidos a alguma unidade e atribui a listagem ao grid
                grdUsuarios.DataSource = (from u in Usuario.Todos where u.Unidade != null select u).ToList();
                //gera o html ná página
                grdUsuarios.DataBind();
                //cria uma lista na memória
                ViewState["moradores"] = new List<int>();
            }
        }

        /// <summary>
        /// evento disparado pelo botão salvar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalvar_Click1(object sender, EventArgs e)
        {
            //bisca a lista de moradores selecionados
            List<int> lista = (List<int>)ViewState["moradores"];

            
            if (lista.Count > 0)
            {
                //abre a transação
                using (TransactionScope trans = new TransactionScope())
                {
                    try
                    {
                        //cria o template da mensagem
                        Domain.Model.Mensagem mensagem = new Domain.Model.Mensagem();
                        mensagem.Usuario = txtUsuario.Text;
                        mensagem.Detalhe = txtMensagem.Text;
                        mensagem.CreateAndFlush();


                        Usuario user = new Usuario();
                        MensagensDosUsuarios mensagemRelacionada;
                        //envia a mensagem para casa usuário selecionado
                        foreach (var item in lista)
                        {
                            user.Id = item;
                            mensagemRelacionada = new MensagensDosUsuarios();
                            mensagemRelacionada.Mensagem = mensagem;
                            mensagemRelacionada.Usuario = user;
                            mensagemRelacionada.CreateAndFlush();
                        }
                        //commit da transação
                        trans.VoteCommit();
                    }
                    catch (Exception ex)
                    {
                        //rollback da transação
                        trans.VoteRollBack();
                        //grava o erro em um log
                        Logger.Error(ex.Message);
                        base.ExibirMensagemErro();
                    }
                }
                base.ExibirMensagemSucesso(Funcionalidade.Mensagem, Operacao.Inclusao);
            }
            else
            {
                pnlMensagem.ExibirMensagem("Selecione os usuários para quem você vai enviar a mensagem");
            }
        }

        /// <summary>
        /// evento disparado pelo checkbox selecionar todos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            //se o checkbox foi marcado
            if (chkTodos.Checked)
            {
                //recupera a lista da memória
                List<int> lista = (List<int>)ViewState["moradores"];
                //para cada linha da grid, marca o checkbox correspondente
                foreach (GridViewRow item in grdUsuarios.Rows)
                {
                    ((CheckBox)item.Cells[0].FindControl("chkMarcar")).Checked = true;
                    int id = int.Parse(((GridViewRow)((CheckBox)item.Cells[0].FindControl("chkMarcar")).Parent.Parent).Cells[3].Text);
                    //se a lista ainda não contiver o id do checkbox
                    if (!lista.Contains(id))
                    {
                        //adiciona o id na lista e devolve a lista na memória
                        lista.Add(id);
                        ViewState["moradores"] = lista;
                    }
                }
            }
        }

        /// <summary>
        /// evento disparado pelo checkbox da grid de usuários
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void chkMarcar_CheckedChanged(object sender, EventArgs e)
        {
            //recupera a lista da grid
            List<int> lista = (List<int>)ViewState["moradores"];
            int id = int.Parse(((GridViewRow)((CheckBox)sender).Parent.Parent).Cells[3].Text);
            //se o checkbox foi desmarcado
            if (!((CheckBox)sender).Checked)
            {
                //desmarca o checkbox que indica que todos estão marcados
                chkTodos.Checked = false;
                //se o id estiver na lista, remove e atribui na memória
                if (lista.Contains(id))
                {
                    lista.Remove(id);
                    ViewState["moradores"] = lista;
                }
            }
            else
            {
                //se o id não estiver na memória, adiciona e atribui na memória
                if (!lista.Contains(id))
                {
                    lista.Add(id);
                    ViewState["moradores"] = lista;
                }
            }
        }
    }
}