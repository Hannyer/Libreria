using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    if ((Session["Usuario"] as SegUsuarioE) != null) {
                        string[] nombre = (Session["Usuario"] as SegUsuarioE).Nombre.Split(' ');
                        string NombreMostrar = nombre[0].Substring(0, 1) + "." + nombre[1];
                        lblNombreDrop.InnerText = nombre[0] + " " + nombre[1];
                        lblUsuario.InnerText = NombreMostrar;
                    }
             
                }
                catch (Exception ex)
                {

                    throw;
                }
        
            }


        }

        protected void btnCerrarsesion_Click(object sender, EventArgs e)
        {

        }

        protected void btnCambiarContrasenna_Click(object sender, EventArgs e)
        {

        }

        protected void btnAprobacionesPendiente_Click(object sender, EventArgs e)
        {

        }

        protected void ddlCompannias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}