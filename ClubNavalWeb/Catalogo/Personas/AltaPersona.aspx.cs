using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using BussinesLogic;
using System.IO;
using Presentation.Utilerias;

namespace Presentation.Catalogo.Personas
{
    public partial class AltaPersona : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Utileria.EnumToListBox(typeof(CargoPersona), ddlCargo, true);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var persona = new VOPersona
                {
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    Nombre = txtNombre.Text,
                    Correo = txtCorreo.Text,
                    Cargo = int.Parse(ddlCargo.SelectedValue),
                    UrlFoto = lblUrlFoto.InnerText
                };
                BLLPersona.InsertarPersona(persona);
                LimpiarFormulario();
                Response.Redirect("ListaPersonas.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), $"Mensaje de error",
                    "alert(Se registró un error al realizar la operación " + ex.Message + ");", true);
            }
        }

        protected void btnSubirImagen_Click(object sender, EventArgs e)
        {
            if (subirImagen.Value.Length > 0)
            {
                var fileName = Path.GetFileName(subirImagen.PostedFile.FileName);
                var extension = Path.GetExtension(fileName).ToLower();
                if (extension != ".jpg" && extension != ".png")
                {
                    lblUrlFoto.InnerText = "Archivo no valido";
                    return;
                }
                var path = Server.MapPath("~/Imagenes/Personas/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                subirImagen.PostedFile.SaveAs(path + fileName);
                var url = "/Imagenes/Personas/" + fileName;
                lblUrlFoto.InnerText = url;
                imgFotoPersona.ImageUrl = url;
                btnGuardar.Visible = true;
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            ddlCargo.SelectedIndex = 0;
            lblUrlFoto.InnerText = string.Empty;
            imgFotoPersona.ImageUrl = string.Empty;
            btnGuardar.Visible = false;
        }
    }
}