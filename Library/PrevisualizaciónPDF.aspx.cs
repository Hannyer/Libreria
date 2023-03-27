using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                txtFechaInicial.Text = DateTime.Now.ToShortDateString();
                txtFechaFinal.Text = DateTime.Now.ToShortDateString();
                await LlenarTabla();
            }

        }

        protected async void btnConsultar_Click(object sender, EventArgs e)
        {
            await LlenarTabla();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        public async void Limpiar()
        {

            txtFechaInicial.Text = DateTime.Now.ToShortDateString();
            txtFechaFinal.Text = DateTime.Now.ToShortDateString();
            await LlenarTabla();
        }
        protected void dgvAsignacion_PreRender(object sender, EventArgs e)
        {
            if (dgvAsignacion.Rows.Count > 0)
            {
                dgvAsignacion.UseAccessibleHeader = true;
                dgvAsignacion.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void dgvAsignacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                string Prioridad_Media = "#ff9933";
                string Prioridad_Alta = "#ff1a1a";
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int index = e.Row.RowIndex;
                    int prioridad = Convert.ToInt32(dgvAsignacion.DataKeys[index].Values[8]?.ToString());
                    if (prioridad == 1)
                    {
                        e.Row.Cells[0].Attributes["style"] = "background-color: " + Prioridad_Media;
                        e.Row.Cells[1].Attributes["style"] = "background-color:" + Prioridad_Media;
                        e.Row.Cells[2].Attributes["style"] = "background-color:" + Prioridad_Media;
                        e.Row.Cells[3].Attributes["style"] = "background-color:" + Prioridad_Media;
                        e.Row.Cells[4].Attributes["style"] = "background-color:" + Prioridad_Media;
                        e.Row.Cells[5].Attributes["style"] = "background-color:" + Prioridad_Media;
                        e.Row.Cells[6].Attributes["style"] = "background-color:" + Prioridad_Media;
                    }
                    else
                    {
                        if (prioridad == 2)
                        {
                            e.Row.Cells[0].Attributes["style"] = "background-color:" + Prioridad_Alta;
                            e.Row.Cells[1].Attributes["style"] = "background-color: " + Prioridad_Alta;
                            e.Row.Cells[2].Attributes["style"] = "background-color: " + Prioridad_Alta;
                            e.Row.Cells[3].Attributes["style"] = "background-color: " + Prioridad_Alta;
                            e.Row.Cells[4].Attributes["style"] = "background-color: " + Prioridad_Alta;
                            e.Row.Cells[5].Attributes["style"] = "background-color: " + Prioridad_Alta;
                            e.Row.Cells[6].Attributes["style"] = "background-color: " + Prioridad_Alta;

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                Mensaje("Error", ex.Message.Replace("'", ""), "error");
            }

        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            DocumentosE oDocumentos = new DocumentosE();

            GridViewRow row = ((GridViewRow)((LinkButton)sender).NamingContainer);
            int index = row.RowIndex;
            oDocumentos = null;
            oDocumentos = DocumentosD.ObtenerDocumentos(new DocumentosE() { Opcion = 0, Clave = dgvAsignacion.DataKeys[index].Values[0].ToString(), Fecha_Inicio = Convert.ToDateTime(txtFechaInicial.Text), Fecha_Final = Convert.ToDateTime(txtFechaFinal.Text) }).Result.FirstOrDefault();
          

            if (oDocumentos != null)
            {
                PrevisualizarPDFConArregloBytes(oDocumentos.pdf);
            }
        }



        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        public void PrevisualizarPDFConArregloBytes(byte[] oDocumento)
        {
            if (oDocumento != null)
            {
                MemoryStream stream = new MemoryStream(oDocumento);
                string docBase64 = "data:application/pdf;base64," + Convert.ToBase64String(oDocumento);
                //ifrPDF.Attributes.Add("data", docBase64);
                HtmlGenericControl texto = new HtmlGenericControl();
                texto.TagName = "p";
                texto.InnerText = "Vista previa del PDF no soportada en este navegador";
                HtmlGenericControl link = new HtmlGenericControl();
                link.TagName = "a";
                link.Attributes.Add("href", docBase64);
                link.Attributes.Add("class", "btn btn-default");
                link.Attributes.Add("download", "EjemploFirma.pdf");
                link.InnerText = "Descargar PDF";
                HtmlGenericControl myObject = new HtmlGenericControl();
                myObject.Controls.Add(texto);
                myObject.Controls.Add(link);
                myObject.TagName = "object";
                myObject.Attributes.Add("data", docBase64);
                myObject.Attributes.Add("type", "application/pdf");
                myObject.Attributes.Add("width", "100%");
                myObject.Attributes.Add("class", "objectPDF");
                myObject.Attributes.Add("min-height", "400px");
                myObject.Attributes.Add("height", "100%");
                myObject.Controls.Add(texto);
                //myObject.Controls.Add(link);
                divPDF.Controls.Add(myObject);
                // divPDF.Attributes.Add("min-height","500px");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalPDFPrevisualizador", "$('#modalPDF').modal('show');", true);
            }
        }
        private async Task LlenarTabla()
        {
            try
            {
                List<DocumentosE> lista = await DocumentosD.ObtenerDocumentos(new DocumentosE()
                {
                    Opcion = 0,
                    //Usuario = (Session["Usuario"] as SegUsuarioE).ID,
                    //Consecutivo = txtDocumento.Text,
                    //EmisorBusqueda = txtProvedor.Text,
                    Fecha_Inicio = Convert.ToDateTime(txtFechaInicial.Text),
                    Fecha_Final = Convert.ToDateTime(txtFechaFinal.Text)
                });
                if (lista.Count > 0)
                {
                    dgvAsignacion.DataSource = lista;
                    dgvAsignacion.DataBind();
                    lblMensaje.Text = "";
                    lblMensaje.Visible = false;
                    //btnAsignarDepartamento.Visible = true;
                }
                else
                {
                    dgvAsignacion.DataSource = null;
                    dgvAsignacion.DataBind();
                    lblMensaje.Text = "No hay documentos con esos parámetros";
                    lblMensaje.Visible = true;
                    //btnAsignarDepartamento.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Mensaje("Error", ex.Message.Replace("'", ""), "error");
                return;
            }
        }
        private void Mensaje(string titulo, string msg, string Icono, string textoBoton = "Ok")
        {
            // string icono = esCorrecto ? "success" : "error";
            string script = "swal({ title: '" + titulo + "!', text: '" + msg + "', icon: '" + Icono + "', button: '" + textoBoton + "' })";
            ScriptManager.RegisterStartupScript(this, GetType(), "script", script, true);
        }
    }
}