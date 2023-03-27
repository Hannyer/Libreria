using CapaEntidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class SegUsuarioD
    {

       

        public static async Task<List<SegUsuarioE>> ObtenerUsuario(SegUsuarioE pUsuario,string Esquena)
        {
            try
            {
                List<SegUsuarioE> Lista = new List<SegUsuarioE>();
                using (var CLient = new HttpClient())
                {
                    var uri = new Uri(URL.ObtenerUsuario() + "?Esquema="+Esquena);
                    var conten = new StringContent(JsonConvert.SerializeObject(pUsuario), Encoding.UTF8, "application/json");
                    HttpResponseMessage respuesta = CLient.PostAsync(uri, conten).Result;

                    if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        if (respuesta.IsSuccessStatusCode)
                        {
                            Lista =  JsonConvert.DeserializeObject<List<SegUsuarioE>>(respuesta.Content.ReadAsStringAsync().Result);
                        }
                    }
                }
                return  Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
