using BussinesLogic;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubNavalWeb.Catalogo.Barcos
{
    public partial class AltaBarco : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CatalogoDueños(ddlOwner);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubirImagen_Click(object sender, EventArgs e)
        {

        }

        public void CatalogoDueños(DropDownList dll)
        {
            int[] cargo = { 1, 3 };
            List<VOPersona> dueños = BLLPersona.CalatogoDueños(cargo, true);
            dueños.ForEach(persona=> dll.Items.Add(new ListItem(persona.Nombre, persona.IdPersona.ToString())));
        }

        public void LimpiarFormulario()
        {
            txtMatricula.Text = string.Empty;
            txtNoAmarre.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtCuota.Text = string.Empty;
            ddlOwner.SelectedIndex = 0;
            lblUrlFoto.InnerText = "";
            imgFotoBarco.ImageUrl = "";
            btnGuardar.Visible = true;
        }
    }
}