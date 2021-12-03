using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using BussinesLogic;

namespace ClubNavalWeb.Salidas
{
    public partial class SalidasProceso : Page
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
            var salidas = BLLSalida.ConsultarSalidaPorEstadoExtendida("EN_PROCESO");
            gvSalidas.DataSource = salidas;
            gvSalidas.DataBind();
        }

        protected void gvSalidas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                var index = int.Parse(e.CommandArgument.ToString());
                var idSalida = gvSalidas.DataKeys[index].Values["IdSalida"].ToString();
                Response.Redirect("DetallesSalida.aspx?Id=" + idSalida);
            }
        }

        
    }
}