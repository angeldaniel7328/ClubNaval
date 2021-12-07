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
    public partial class AltaSalida : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CatalogoPersonas(ddlCapitan, new int[]{ 2, 3 });
                CatalogoPersonas(ddlOwner, new int[] { 1, 3 });
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var salida = new VOSalida
                {
                    FechaHoraSalida = DateTime.Parse(FechaSalida.Value.ToString()),
                    Destino = txtDestino.Text,
                    Estado = "EN_PROCESO",
                    IdBarco = int.Parse(ddlCapitan.SelectedValue),
                    IdPersona = int.Parse(ddlCapitan.SelectedValue)
                };
                BLLSalida.InsertarSalida(salida);
                LimpiarFormulario();
                Response.Redirect("SalidasProceso.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), $"Mensaje de error",
                    "alert(Se registró un error al realizar la operación " + ex.Message + ");", true);
            }
        }

        protected void ddlOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = ddlOwner.SelectedValue;
            CatalogoBarcos(id);
        }

        private void CatalogoPersonas(DropDownList ddl, int[] cargo)
        {
            var personas = BLLPersona.CatalogoPersona(cargo, true);
            personas.ForEach(persona => ddl.Items.Add(new ListItem(persona.Nombre, persona.IdPersona.ToString())));
        }

        private void CatalogoBarcos(string idOwner)
        {
            ddlBarco.Items.Clear();
            var barcos = BLLBarco.ConsultarBarcosPorDueño(idOwner, true);
            barcos.ForEach(barco => ddlBarco.Items.Add(new ListItem(barco.Matricula, barco.IdBarco.ToString())));
        }

        private void LimpiarFormulario()
        {
            txtDestino.Text = string.Empty;
            FechaSalida.Value = string.Empty;
            ddlCapitan.SelectedIndex = 0;
            ddlOwner.SelectedIndex = 0;
            ddlBarco.SelectedIndex = 0;
        }
    }
}