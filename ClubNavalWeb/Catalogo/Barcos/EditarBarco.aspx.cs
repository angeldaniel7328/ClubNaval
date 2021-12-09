using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using BussinesLogic;
using System.IO;
using System.Drawing;

namespace Presentation.Catalogo.Barcos
{
    public partial class EditarBarco : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CatalogoDueños(ddlOwner);
                if (Request.QueryString["Id"] == null)
                    Response.Redirect("ListaBarcos.aspx");
                else
                {
                    var idBarco = Request.QueryString["Id"].ToString();
                    var barco = BLLBarco.ConsultarBarcoPorId(idBarco);
                    CargarFormulario(barco);
                    var disponibilidad = (bool)barco.Disponibilidad;
                    lblBarco.ForeColor = disponibilidad ? Color.Green : Color.Red;
                    btnEliminar.Visible = disponibilidad;
                }
            }
        }

        private void CargarFormulario(VOBarco barco)
        {
            lblBarco.Text = barco.IdBarco.ToString();
            txtMatricula.Text = barco.Matricula.ToString();
            txtNoAmarre.Text = barco.NoAmarre;
            txtNombre.Text = barco.Nombre;
            txtCuota.Text = barco.Cuota.ToString();
            ddlOwner.SelectedValue = barco.IdOwner.ToString();
            lblUrlFoto.InnerText = barco.UrlFoto;
            imgFotoBarco.ImageUrl = barco.UrlFoto;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                BLLBarco.EliminarBarco(lblBarco.Text);
                LimpiarFormulario();
                Response.Redirect("ListaBarcos.aspx");
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
                var path = Server.MapPath("~/Imagenes/Barcos/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                SubirImagen.PostedFile.SaveAs(path + fileName);
                var url = "/Imagenes/Barcos/" + fileName;
                lblUrlFoto.InnerText = url;
                imgFotoBarco.ImageUrl = url;
                btnGuardar.Visible = true;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var barco = new VOBarco
                {
                    IdBarco = int.Parse(lblBarco.Text),
                    Matricula = txtMatricula.Text,
                    NoAmarre = txtNoAmarre.Text,
                    Nombre = txtNombre.Text,
                    Cuota = double.Parse(txtCuota.Text),
                    IdOwner = int.Parse(ddlOwner.SelectedValue),
                    UrlFoto = lblUrlFoto.InnerText
                };
                BLLBarco.ActualizarBarco(barco);
                LimpiarFormulario();
                Response.Redirect("ListaBarcos.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), $"Mensaje de error",
                    "alert(Se registró un error al realizar la operación " + ex.Message + ");", true);
            }
        }

        public void CatalogoDueños(DropDownList dll)
        {
            var dueños = BLLPersona.CatalogoPersona(new int[] { 1, 3 }, true);
            dueños.ForEach(persona => dll.Items.Add(new ListItem(persona.Nombre, persona.IdPersona.ToString())));
        }

        public void LimpiarFormulario()
        {
            lblBarco.Text = string.Empty;
            txtMatricula.Text = string.Empty;
            txtNoAmarre.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtCuota.Text = string.Empty;
            ddlOwner.SelectedIndex = 0;
            lblUrlFoto.InnerText = "";
            imgFotoBarco.ImageUrl = "";
            btnGuardar.Visible = false;
        }

    }
}