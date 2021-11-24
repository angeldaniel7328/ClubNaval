using BussinesLogic;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
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
            try
            {
                VOBarco barco = new VOBarco
                {
                    Matricula = txtMatricula.Text,
                    NoAmarre = txtNoAmarre.Text,
                    Nombre = txtNombre.Text,
                    Cuota = double.Parse(txtCuota.Text),
                    IdOwner = int.Parse(ddlOwner.SelectedValue),
                    UrlFoto = lblUrlFoto.InnerText,
                    Disponibilidad = true
                };
                BLLBarco.InsertarBarco(barco);
                LimpiarFormulario();
                Response.Redirect("ListaBarco.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), $"Mensaje de error",
                    "alert(Se registró un error al realizar la operación " + ex.Message +");", true);
            }
        }

        protected void btnSubirImagen_Click(object sender, EventArgs e)
        {
            if (subirImagen.Value.Length > 0)
            {
                var fileName = Path.GetFileName(subirImagen.PostedFile.FileName);
                var extension = Path.GetExtension(fileName).ToLower();
                if (extension!=".jpg" && extension != ".png")
                {
                    lblUrlFoto.InnerText = "Archivo no valido";
                    return;
                }
                var path = Server.MapPath("~/Imagenes/Barcos/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                subirImagen.PostedFile.SaveAs(path + fileName);
                var url = "/Imagenes/Barcos/" + fileName;
                lblUrlFoto.InnerText = url;
                imgFotoBarco.ImageUrl = url;
                btnGuardar.Visible = true;
            }
        }

        public void CatalogoDueños(DropDownList dll)
        {
            int[] cargo = { 1, 3 };
            var dueños = BLLPersona.CatalogoPersona(cargo, true);
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