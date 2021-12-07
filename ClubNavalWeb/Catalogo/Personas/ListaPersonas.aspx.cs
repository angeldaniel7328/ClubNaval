using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using BussinesLogic;

namespace Presentation.Catalogo.Personas
{
    public partial class ListaPersonas : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }

        private void CargarGrid()
        {
            gvPersonas.DataSource = BLLPersona.ConsultarPersonas(null);
            gvPersonas.DataBind();
        }

        protected void gvPersonas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                var index = int.Parse(e.CommandArgument.ToString());
                var idPersona = gvPersonas.DataKeys[index].Values["IdPersona"].ToString();
                Response.Redirect("EditarPersona.aspx?id=" + idPersona);
            }
        }
    }
}