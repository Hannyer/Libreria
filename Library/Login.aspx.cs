using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                SegUsuarioE usuario =  SegUsuarioD.ObtenerUsuario(new SegUsuarioE()
                {
                    Opcion = 0,
                    Contrasenna = txtContrasenna.Text,
                  Identificacion=txtCedula.Text
                },"LIBRARY").Result.FirstOrDefault() ;

                if (Validar(usuario))
                {
                    return;
                }
                string script = "swal({ title:'Usuario correcto!' , text:  'Bienvenido " + usuario.Nombre + "!' , icon: 'success',timer: 2000,buttons: false }).then(function(){window.location = 'Default.aspx';})";
                ScriptManager.RegisterStartupScript(this, GetType(), "script", script, true);
            }
            catch (Exception ex)
            {
                Mensaje("Error",ex.Message.Replace("'",""),false);
            }
        }



        private void Mensaje(string titulo, string msg, bool esCorrecto, string textoBoton = "Ok")
        {
            string icono = esCorrecto ? "success" : "error";
            string script = "swal({ title: '" + titulo + "!', text: '" + msg + "', icon: '" + icono + "', button: '" + textoBoton + "' })";
            ScriptManager.RegisterStartupScript(this, GetType(), "script", script, true);
        }


        public bool Validar(SegUsuarioE Usuario) {
            if (txtCedula.Text == "")
            {
                Mensaje("Error", "Debe digitar la identificación", false);
                return true;
            }
            if (txtContrasenna.Text == "")
            {
                Mensaje("Error", "Debe digitar la contraseña", false);
                return true;
            }
            if (Usuario ==null)
            {
                Mensaje("Error", "No se ha encontrado el usuario, favor verificar los datos", false);
                return true;
            }

            return false;
        }


    }
}