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
using System.Drawing;

namespace Presentation.Catalogo.Personas
{
    public partial class EditarPersona : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Utileria.EnumToListBox(typeof(CargoPersona), ddlCargo, true);
                if (Request.QueryString["Id"] == null)
                    Response.Redirect("ListaPersonas.aspx");
                else
                {
                    var idPersona = Request.QueryString["Id"].ToString();
                    var persona = BLLPersona.ConsultarPersonaPorId(idPersona);
                    CargarFormulario(persona);
                    var disponibilidad = (bool)persona.Disponibilidad;
                    lblPersona.ForeColor = disponibilidad ? Color.Green : Color.Red;
                    btnEliminar.Visible = disponibilidad;
                }
            }
        }

        private void CargarFormulario(VOPersona persona)
        {
            lblPersona.Text = persona.IdPersona.ToString();
            txtNombre.Text = persona.Nombre;
            txtTelefono.Text = persona.Telefono;
            txtDireccion.Text = persona.Direccion;
            txtCorreo.Text = persona.Correo;
            ddlCargo.SelectedValue = persona.Correo;
            lblUrlFoto.InnerText = persona.UrlFoto;
            imgFotoPersona.ImageUrl = persona.UrlFoto;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                BLLBarco.EliminarBarco(lblPersona.Text);
                LimpiarFormulario();
                Response.Redirect("ListaPersonas.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), $"Mensaje de error",
                    "alert(Se registró un error al realizar la operación " + ex.Message + ");", true);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var persona = new VOPersona
                {
                    IdPersona = int.Parse(lblPersona.Text.ToString()),
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    Nombre = txtNombre.Text,
                    Correo = txtCorreo.Text,
                    Cargo = int.Parse(ddlCargo.SelectedValue),
                    UrlFoto = lblUrlFoto.InnerText
                };
                BLLPersona.ActualizarPersona(persona);
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
            if (SubirImagen.Value.Length > 0)
            {
                var fileName = Path.GetFileName(SubirImagen.PostedFile.FileName);
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
                SubirImagen.PostedFile.SaveAs(path + fileName);
                var url = "/Imagenes/Personas/" + fileName;
                lblUrlFoto.InnerText = url;
                imgFotoPersona.ImageUrl = url;
                btnGuardar.Visible = true;
            }
        }

        private void LimpiarFormulario()
        {
            lblPersona.Text = string.Empty;
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