using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Web.Pages
{
    public partial class PainelMensagem : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [Bindable(true)]
        [Localizable(true)]
        public string Titulo
        {
            get
            {
                return lblTitulo.Text;
            }
            set
            {
                lblTitulo.Text = value;
            }
        }

        public void ExibirMensagem(string mensagem)
        {
            lblMensagem.Text = mensagem;
        }

        public void EsconderMensagem()
        {
            lblMensagem.Text = string.Empty;
        }

    }
}