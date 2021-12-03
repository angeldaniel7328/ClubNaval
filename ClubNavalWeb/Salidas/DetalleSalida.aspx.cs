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
    public partial class DetalleSalida : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    Response.Redirect("SalidasProceso.aspx");
                }
                else
                {
                    var idSalida = Request.QueryString["Id"].ToString();
                    var salida = BLLSalida.ConsultarSalidaPorIdExtendida(idSalida);
                    CargarFormulario(salida);
                }
            }
        }

        private void CargarFormulario(VOSalidaExtendida salida)
        {
            lblIdSalida.Text = salida.IdSalida.ToString();
            lblFecha.Text = salida.FechaHoraSalida.ToString();
            lblDestino.Text = salida.Destino;
            lblNombreCapitan.Text = salida.NombreCapitan;
            imgFotoCapitan.ImageUrl = salida.UrlFotoCapitan;
            lblNombreBarco.Text = salida.NombreBarco;
            imgFotoBarco.ImageUrl = salida.UrlFotoBarco;
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                BLLSalida.FinalizarSalida(lblIdSalida.Text);
                LimpiarFormulario();
                Response.Redirect("SalidasFinalizadas.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), $"Mensaje de error",
                    "alert(Se registró un error al realizar la operación " + ex.Message + ");", true);
            }
        }

        private void LimpiarFormulario()
        {
            lblIdSalida.Text = string.Empty;
            lblFecha.Text = string.Empty;
            lblDestino.Text = string.Empty;
            lblNombreCapitan.Text = string.Empty;
            imgFotoCapitan.ImageUrl = string.Empty;
            lblNombreBarco.Text = string.Empty;
            imgFotoBarco.ImageUrl = string.Empty;
        }
    }
}