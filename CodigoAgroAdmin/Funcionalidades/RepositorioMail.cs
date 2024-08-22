using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Funcionalidades
{
    public class RepositorioMail
    {
        private MailMessage email;
        private SmtpClient server;
        public void EmailService()
        {                
            server = new SmtpClient();
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
            server.Credentials = new System.Net.NetworkCredential("dotcomaterrizar@gmail.com", "ltor uzlk cnqo wqhz ");


        }

        public void armarCorreo(string destinatario, string asunto, string mensaje,string nombre,string apellido)
        {
            email = new MailMessage();
            email.From = new MailAddress("dotcomaterrizar@gmail.com");
            email.To.Add(destinatario);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = "<h1>¡Hola!</h1><h2>" + nombre + " " + apellido + "</h2><p>Te enviamos este correo para informarte que tu informacion ha sido guardada.</p><p>¡Pronto te contactaremos!</p>";
            //email.Body = mensaje;
        }

        public void enviarCorreo()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //Mail con imagen incrustada en el cuerpo para enviar el codigo qr de confirmacion de reserva.
        public MailMessage ArmarCorreoConImagen(string destinatario, string asunto)
        {
            email = new MailMessage();

            email.IsBodyHtml = true;
            email.From = new MailAddress("dotcomaterrizar@gmail.com");
            email.To.Add(destinatario);
            email.Subject = asunto;
            //email.Body = "<h1>¡Hola!</h1><p>Te enviamos este correo para confirmar tu reserva.</p><p>Porfavor, escanee el codigo qr a continuacion.</p>";
            //Obtiene la direccion de la imagen en cualquier computadora que ejecute el programa.
            string directorioBase = AppDomain.CurrentDomain.BaseDirectory;
            //va a la carpeta Imagenes/qecodigoprueba.png
            //Este codigo QR es un link a https://localhost:44305/ConfirmacionReserva.aspx ya que es un servidor local.
            //Se podria reemplazar con la direccion real en caso de que se suba a un servidor.
            string directorioRelativo = Path.Combine(directorioBase, "Imagenes", "qrcodigoprueba.png");
            //añade la imagen al correo.
            email.AlternateViews.Add(ObtenerImagenIncrustada(directorioRelativo));

            return email;
        }

        //obtencion de la imagen e incrustacion en el correo
        public AlternateView ObtenerImagenIncrustada(String ubicacionArchivo)
        {
            //Se crea un Recurso de tipo LinkedResource para linkear la imagen al correo.
            LinkedResource recurso = new LinkedResource(ubicacionArchivo);
            recurso.ContentId = Guid.NewGuid().ToString();
            //Cuerpo html del correo + incrustacion de imagen.
            string cuerpoHtml = $@"<html><body><h1>¡Hola!</h1><p>Te enviamos este correo para confirmar tu reserva.</p><p>Porfavor, escanee el codigo qr a continuacion.</p>""<img src='cid:{recurso.ContentId}'/></body></html>";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(cuerpoHtml, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(recurso);
            return alternateView;
        }


    }
}
