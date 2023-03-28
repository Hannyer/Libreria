using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class URL
    {
        //public static string URL_BASE = "http://192.168.0.163/Api_Libreria/";
       public static string URL_BASE = "http://10.6.1.119/Api_Libreria/";


        //usuarios BD library
        public static string ObtenerUsuario()
        {
            return URL_BASE+"Obtener";
        }


        //obtener documentos base de datos matriz y de
        public static string ObtenerDocumentos()
        {
            return URL_BASE + "ObtenerDocumentos";
        }

    }
}
