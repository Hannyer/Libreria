using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class UtilitarioE
    {
        //metodo que envia parámetro y ejecuta el metodo Desencriptar
        public static string DesencriptarString(string textoEncriptado)
        {
            return Desencriptar(textoEncriptado, "CualquierValor", "s@lAvz", "MD5",
              1, "@1B2c3D4e5F6g7H8", 128);
        }
        //metodo que envia parámetro y ejecuta el metodo encriptar
        public static string EncriptarString(string stringEncriptado)
        {
            return Encriptar(stringEncriptado,
              "CualquierValor", "s@lAvz", "MD5", 1, "@1B2c3D4e5F6g7H8", 128);
        }
        //metodo encargado de Encriptar nuestro texto 
        public static string Encriptar(string textoQueEncriptaremos, string passBase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(textoQueEncriptaremos);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passBase,
              saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged()
            {
                Mode = CipherMode.CBC
            };
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes,
              initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor,
             CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string cipherText = Convert.ToBase64String(cipherTextBytes);
            return cipherText;
        }

        public static string Desencriptar(string textoEncriptado, string passBase,
        string saltValue, string hashAlgorithm, int passwordIterations,
        string initVector, int keySize)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] cipherTextBytes = Convert.FromBase64String(textoEncriptado);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passBase,
              saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged()
            {
                Mode = CipherMode.CBC
            };
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes,
              initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor,
              CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0,
              plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            string plainText = Encoding.UTF8.GetString(plainTextBytes, 0,
              decryptedByteCount);
            return plainText;
        }

        //public string EnviarCorreo(SegUsuarioE oUsuario)
        //{

        //    //string rutaImgLogo = @"~\Assets\img\LogosEmpresa\FirmaCorreo.png";
        //    //string contentID1 = "logoEmpresa";
        //    //Creamos un nuevo Objeto de mensaje
        //    //Creamos un nuevo Objeto de mensaje
        //    System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
        //    System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

        //    SegPerfilE oPerfil = new SegPerfilL().Obtener(new SegPerfilE() { Opcion = 0, Usuario = (Session["Usuario"] as SegUsuarioE).ID, ID = oUsuario.FK_Perfil }, (Session["Usuario"] as SegUsuarioE).ID_Compannia, Session["Key_Usuario_log"].ToString()).FirstOrDefault();

        //    try
        //    {

        //        //Attachment inlineLogo = new Attachment(Server.MapPath(rutaImgLogo));
        //        //inlineLogo.ContentId = contentID1;
        //        ////haciendo que la imagen no se inserte como un adjunto al correo
        //        //inlineLogo.ContentDisposition.Inline = true;
        //        //inlineLogo.ContentDisposition.DispositionType = DispositionTypeNames.Inline;

        //        //Direccion de correo electronico a la que queremos enviar el mensaje
        //        try
        //        {
        //            mmsg.To.Add(oUsuario.Correo);
        //        }
        //        catch (Exception)
        //        {
        //            return oUsuario.Correo;
        //        }

        //        //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

        //        //Asunto
        //        mmsg.Subject = "Usuario registrado ";
        //        //mmsg.Subject = "Solicitud de cotización";
        //        mmsg.SubjectEncoding = System.Text.Encoding.UTF8;


        //        //Cuerpo del Mensaje

        //        StringBuilder mensaje = new StringBuilder();

        //        mensaje.Append(@"<h1 style='text-align:center'><b> Usuario " + txtNombre.Text + "</b></h1>" +
        //  "<p><b> Estimado(a) Usuario: </b>" + txtNombre.Text.ToUpper() + "</p>" +
        //    "<p> Se ha registrado su Usuario el día " + DateTime.Now.ToString("dd/MM/yyyy") + "</p>" +
        //    "<p>Datos del Usuario:</p>" +
        //    "<p>Usuario: " + oUsuario.ID + "</p>" +
        //    "<p>Nombre: " + oUsuario.Nombre + "</p>" +
        //    "<p>Contraseña: " + oUsuario.Contrasenna + "</p>" +



        //    "<p>Perfil: " + oPerfil.Descripcion + "</p>" +
        //    "<p><em>No responder este correo, ya que se generó de forma automática por el sistema MTRA<em></p>" +
        //       "<p>Gracias.</p>" +
        //       "<p>&nbsp;</p> ");


        //        // mensaje =
        //        //"<p> <img src='cid:" + contentID1 + "' width='450' height='150'/></p> ";





        //        mmsg.Body = mensaje.ToString();
        //        //Attachment adjunto = new Attachment(archivo);
        //        //mmsg.Attachments.Add(adjunto);

        //        mmsg.BodyEncoding = System.Text.Encoding.UTF8;
        //        mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML


        //        //correo de alias 




        //        string CorreoAlias = string.Empty;
        //        if (string.IsNullOrEmpty((Session["Usuario"] as SegUsuarioE).Correo))
        //        {
        //            CorreoAlias = GlobalE.CorreoSalida;
        //        }
        //        else
        //        {
        //            CorreoAlias = (Session["Usuario"] as SegUsuarioE).Correo;
        //        }

        //        string NombreUsuario = (Session["Usuario"] as SegUsuarioE).Nombre;


        //        //Correo electronico desde la que enviamos el mensaje
        //        mmsg.From = new System.Net.Mail.MailAddress(CorreoAlias, NombreUsuario);

        //        mmsg.ReplyToList.Add(new System.Net.Mail.MailAddress(CorreoAlias));

        //        //mmsg.Attachments.Add(inlineLogo);


        //        /*-------------------------CLIENTE DE CORREO----------------------*/


        //        //Hay que crear las credenciales del correo emisor
        //        cliente.Credentials =
        //            //new System.Net.NetworkCredential("taxisirazu@curlingtech.com", "Ir@ZuTaxi$2018");
        //            new System.Net.NetworkCredential(GlobalE.CorreoSalida, GlobalE.ContrasennaCorreoSalida);

        //        /*-------------------------ENVIO DE CORREO----------------------*/
        //        // mail.servidordominio.com
        //        //Para Gmail "smtp.gmail.com";
        //        cliente.Host = GlobalE.SMTPCorreo;

        //        //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
        //        cliente.Port = Convert.ToInt32(GlobalE.PuertoCorreo);
        //        cliente.EnableSsl = false;

        //        //Enviamos el mensaje      
        //        cliente.Send(mmsg);
        //        return "";
        //    }
        //    catch (System.Net.Mail.SmtpException)
        //    {
        //        try
        //        {
        //            cliente.EnableSsl = true;
        //            //Enviamos el mensaje      
        //            cliente.Send(mmsg);
        //            return "";
        //        }
        //        catch (Exception exC)
        //        {
        //            Mensaje("Error", exC.Message.Replace("'", ""), false);
        //            return oUsuario.Correo;
        //        }
        //    }
        //    finally
        //    {
        //        cliente.Dispose();
        //        mmsg.Dispose();
        //    }
        //}


        //Generar serial Aleatorio
        public string Serial()
        {
            return Guid.NewGuid().ToString().Substring(0, 4).ToUpper();

        }

    }
}
