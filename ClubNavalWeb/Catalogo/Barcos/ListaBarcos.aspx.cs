using BussinesLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubNavalWeb.Catalogo.Barcos
{
    public partial class ListaBarcos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }

        public void CargarGrid()
        {
            gvBarcos.DataSource = BLLBarco.ConsultarBarcos(null);
            gvBarcos.DataBind();
        }

        protected void gvBarcos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                var index = int.Parse(e.CommandArgument.ToString());
                var idBarco = gvBarcos.DataKeys[index].Values["IdBarco"].ToString();
                Response.Redirect("EditarBarco.aspx?id=" + idBarco);
            }
        }
    }
}