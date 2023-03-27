using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class UtilitarioEncriptarYDesencriptar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtValorDigitado.Text = "";
            txtValorObtenido.Text = "";
        }

        protected void btnEncriptar_Click(object sender, EventArgs e)
        {
            try
            {
                txtValorObtenido.Text = UtilitarioE.EncriptarString(txtValorDigitado.Text);
            }
            catch (Exception ex)
            {
                Mensaje("Error", ex.Message.Replace("'", "").Replace("\n", "").Replace("\r", ""), false);
            }
        }

        protected void btnDesencriptar_Click(object sender, EventArgs e)
        {
            try
            {
                txtValorObtenido.Text = UtilitarioE.DesencriptarString(txtValorDigitado.Text);
            }
            catch (Exception ex)
            {
                Mensaje("Error", "Ha digitado un valor incorrecto que no se puede desencriptar", false);
            }
        }
        private void Mensaje(string titulo, string msg, bool esCorrecto, string textoBoton = "Ok")
        {
            string icono = esCorrecto ? "success" : "error";
            string script = "Swal.fire({ title: '" + titulo + "!', text: '" + msg + "', icon: '" + icono + "', confirmButtonText: '" + textoBoton + "' })";
            ScriptManager.RegisterStartupScript(this, GetType(), "script", script, true);
        }

        
    }
}