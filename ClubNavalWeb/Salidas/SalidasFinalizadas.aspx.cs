using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using BussinesLogic;

namespace Presentation.Salidas
{
    public partial class SalidasFinalizadas : Page
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
            var salidas = BLLSalida.ConsultarSalidaPorEstadoExtendida("FINALIZADA");
            gvSalidas.DataSource = salidas;
            gvSalidas.DataBind();
        }
    }
}