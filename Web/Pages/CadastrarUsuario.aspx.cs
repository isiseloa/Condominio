using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Model;
using Domain.Util.Security;
using Domain.Util.Diagnostics;

namespace Web.Pages
{
    public partial class CadastrarUsuario : PageBase
    {
        /// <summary>
        /// evento disparado pelo load da página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //obtém o parâmetro da url
                    hddId.Value = Request.QueryString["id"];

                    //verifixa se o usuário é um usuário do tipo comum
                    if (base.UsuarioLogado.TipoDoUsuario == Usuario.TipoUsuario.UsuarioComum)
                    {
                        //desabilita campos
                        txtNome.Enabled = false;
                        txtSobrenome.Enabled = false;
                        txtEmail.Enabled = false;
                        txtUsuario.Enabled = false;
                        txtSenha.Enabled = false;
                        txtUnidade.Enabled = false;
                        ddlStatusUsuario.Enabled = false;
                        ddlTipoUsuario.Enabled = false;
                        btnSalvar.Enabled = false;
                        //remove link de popup de unidades
                        Image1.Attributes.Remove("onclick");
                        //remove itens dos combobox
                        ddlTipoUsuario.Items.RemoveAt(0);
                        ddlTipoUsuario.Items.RemoveAt(0);

                    }
                        //se o usuário for responsável pela unidade
                    else if (base.UsuarioLogado.TipoDoUsuario == Usuario.TipoUsuario.ResponsavelUnidade)
                    {
                        //remove primeiro item do combobox
                        ddlTipoUsuario.Items.RemoveAt(0);

                        //marca a unidade do usuario logado
                        txtUnidade.Text = base.UsuarioLogado.Unidade.Numero;
                        hddIdUnidade.Value = base.UsuarioLogado.Unidade.Id.ToString();
                        //removo o link de unidades
                        Image1.Attributes.Remove("onclick");
                    }

                    // se existe o id recuperado da querystring
                    if (!string.IsNullOrEmpty(hddId.Value))
                    {
                        //efetua a consulta do usuario
                        ConsultarUsuario();
                    }
                }
                else
                {
                    //campos preenchidos com javascript devem ser reatribuidos em um postback
                    txtUnidade.Text = Request.Form["ctl00$ContentPlaceHolder1$txtUnidade"];
                    hddIdUnidade.Value = Request.Form["ctl00$ContentPlaceHolder1$hddIdUnidade"];
                }
            }
            catch (Exception ex)
            {
                //grava a mensagem de erro em arquivo de lo
                Logger.Error(ex.Message);
                base.ExibirMensagemErro();
            }
        }

        /// <summary>
        /// evento disparado pelo botão salvar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            //verifica so os campos estão válidos
            if (Page.IsValid)
            {
                try
                {
                    Usuario user;
                    //verifica se existe o id recuperado da url
                    if (!string.IsNullOrEmpty(hddId.Value))
                    {
                        //consulta o usuário pelo id
                        user = Usuario.FindByPrimaryKey(int.Parse(hddId.Value));

                        //atribui os campos da página para o usuário consultado
                        user.Nome = Request.Form["ctl00$ContentPlaceHolder1$txtNome"];
                        user.Sobrenome = Request.Form["ctl00$ContentPlaceHolder1$txtSobrenome"];
                        user.Email = ((string)Request.Form["ctl00$ContentPlaceHolder1$txtEmail"]).ToLower();
                        user.StatusDoUsuario = (Usuario.Status)int.Parse(Request.Form["ctl00$ContentPlaceHolder1$ddlStatusUsuario"]);
                        if (user.Id != base.UsuarioLogado.Id)
                            user.TipoDoUsuario = (Usuario.TipoUsuario)int.Parse(Request.Form["ctl00$ContentPlaceHolder1$ddlTipoUsuario"]);
                        user.Unidade = Unidade.FindByPrimaryKey(int.Parse(Request.Form["ctl00$ContentPlaceHolder1$hddIdUnidade"]));

                        //atualiza o usuario
                        user.UpdateAndFlush();
                    }
                    else
                    {
                        //cria um novo objeto de usuario
                        user = new Usuario();
                        //atribui os campos da página no objeto criado
                        user.Nome = txtNome.Text.Trim();
                        user.Sobrenome = txtSobrenome.Text.Trim();
                        user.Email = txtEmail.Text.Trim();
                        user.NomeUsuario = txtUsuario.Text.Trim().ToLower();
                        user.StatusDoUsuario = (Usuario.Status)int.Parse(ddlStatusUsuario.SelectedValue);
                        user.TipoDoUsuario = (Usuario.TipoUsuario)int.Parse(ddlTipoUsuario.SelectedValue);
                        user.Unidade = Unidade.FindByPrimaryKey(int.Parse(hddIdUnidade.Value));
                        user.Senha = Criptografia.EncriptMD5(txtSenha.Text.Trim());
                        //salva o registro no banco
                        user.CreateAndFlush();
                    }
                }

                catch (Exception ex)
                {
                    //grava a mensagem de erro em um arquivo texto
                    Logger.Error(ex.Message);
                    base.ExibirMensagemErro();
                }
                base.ExibirMensagemSucesso(Funcionalidade.Usuario, (string.IsNullOrEmpty(hddId.Value)) ? Operacao.Inclusao : Operacao.Alteracao);
            }
        }

        /// <summary>
        /// evento de validação do email
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void EmailUnicoValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                if (string.IsNullOrEmpty(hddId.Value))
                {
                    args.IsValid = ((from u in Usuario.Todos where u.Email == args.Value.Trim().ToLower() select u).Count() == 0);
                }
                else
                {
                    args.IsValid = ((from u in Usuario.Todos where u.Email == args.Value.Trim().ToLower() && u.Id != int.Parse(hddId.Value) select u).Count() == 0);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                base.ExibirMensagemErro();
            }
        }

        /// <summary>
        /// evento de validação do usuário
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void UsuarioUnicoValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                if (string.IsNullOrEmpty(hddId.Value))
                {
                    args.IsValid = ((from u in Usuario.Todos where u.NomeUsuario == args.Value.Trim().ToLower() select u).Count() == 0);
                }
                else
                {
                    args.IsValid = ((from u in Usuario.Todos where u.NomeUsuario == args.Value.Trim().ToLower() && u.Id != int.Parse(hddId.Value) select u).Count() == 0);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                base.ExibirMensagemErro();
            }
        }

        /// <summary>
        /// consulta o usuário pelo id guardado no campo oculto e atribui os valores
        /// nos campos da página
        /// </summary>
        private void ConsultarUsuario()
        {
            //busca o usuário pelo id
            Usuario user = Usuario.FindByPrimaryKey(int.Parse(hddId.Value));
            //atribui os valores nos campos da página
            txtNome.Text = user.Nome;
            txtSobrenome.Text = user.Sobrenome;
            txtEmail.Text = user.Email;
            txtUsuario.Text = user.NomeUsuario;
            txtSenha.Enabled = false;
            if (user.Unidade != null)
            {
                txtUnidade.Text = user.Unidade.Numero;
                hddIdUnidade.Value = user.Unidade.Id.ToString();
            }
            ddlTipoUsuario.SelectedValue = ((int)user.TipoDoUsuario).ToString();
            ddlStatusUsuario.SelectedValue = ((int)user.StatusDoUsuario).ToString();
            validator_senha.Enabled = false;
            txtUsuario.Enabled = false;
            //define regra de negócios para habilitar e desabilitar campos
            bool habilitar = (user.Id == base.UsuarioLogado.Id || base.UsuarioLogado.Unidade == null || user.Unidade == null || (base.UsuarioLogado.Unidade.Id == user.Unidade.Id && base.UsuarioLogado.TipoDoUsuario != Usuario.TipoUsuario.UsuarioComum && user.Id != base.UsuarioLogado.Id));

            //habilita/desabilita campos
            txtNome.Enabled = habilitar;
            txtSobrenome.Enabled = habilitar;
            txtEmail.Enabled = habilitar;
            ddlStatusUsuario.Enabled = habilitar;
            ddlTipoUsuario.Enabled = habilitar;
            btnSalvar.Enabled = habilitar;
            txtUnidade.Enabled = habilitar;

            ddlTipoUsuario.Enabled = (user.Id != base.UsuarioLogado.Id);
        }

        /// <summary>
        /// valida se a unidade está preenchida
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void unidadeValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (!string.IsNullOrEmpty(Request.Form["ctl00$ContentPlaceHolder1$hddIdUnidade"]) && !string.IsNullOrEmpty(Request.Form["ctl00$ContentPlaceHolder1$txtUnidade"]));
        }
    }
}