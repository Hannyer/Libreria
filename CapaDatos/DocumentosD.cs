using CapaEntidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   public  class DocumentosD
    {
        public static async Task<List<DocumentosE>> ObtenerDocumentos(DocumentosE pDocumento)
        {
            try
            {
                List<DocumentosE> Lista = new List<DocumentosE>();
                using (var CLient = new HttpClient())
                {
                    var uri = new Uri(URL.ObtenerDocumentos());
                    var conten = new StringContent(JsonConvert.SerializeObject(pDocumento), Encoding.UTF8, "application/json");
                    HttpResponseMessage respuesta = CLient.PostAsync(uri, conten).Result;

                    if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        if (respuesta.IsSuccessStatusCode)
                        {
                            Lista = JsonConvert.DeserializeObject<List<DocumentosE>>(respuesta.Content.ReadAsStringAsync().Result);
                        }
                    }
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
