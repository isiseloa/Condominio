using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Model;

namespace Web.Pages
{
    public partial class ViewUnidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //efetua a pesquisa de todas as unidades
            grdUnidades.DataSource = Unidade.FindAll();
            //gera o html na página
            grdUnidades.DataBind();
        }
    }
}