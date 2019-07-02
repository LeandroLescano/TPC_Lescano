using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using Dominio;
using AccesoDatos;
using System.Net.Mail;
using System.IO;

namespace negocioCom
{
    public class MailNegocio
    {
        public int agregarMail(Mail nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO MAILS (MAIL, DESCRIPCION) VALUES ('"+nuevo.Direccion+"', '"+nuevo.Descripcion+ "') SELECT SCOPE_IDENTITY();");
                accesoDatos.abrirConexion();
                return accesoDatos.ejecutarAccionReturn();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();

            }
        }

        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();
                    var domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public bool mandarMail(string email, Pedido pedido, string Comentario)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                StreamReader reader = new StreamReader(Path.GetFullPath("Mail.html"));
                if (Comentario != "")
                {
                    Comentario = "Comentario del vendedor: \n" + Comentario;
                }
                string body = reader.ReadToEnd();
                body = body.Replace("{Nombre}", pedido.Cliente.Nombre);
                body = body.Replace("{Comentario}", Comentario);
                body = body.Replace("{Estado}", pedido.Estado);

                mail.From = new MailAddress("promocode.noreply@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Estado de tu pedido";
                mail.IsBodyHtml = true;
                //mail.Body = "Hola " + pedido.Cliente.Nombre + ", \n\nEl estado de tu pedido es: " + pedido.Estado + "\n\n" + Comentario;
                mail.Body = body;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("fiambreria.noreply@gmail.com", "fiambreria123");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch (SmtpFailedRecipientException)
            {
                return false;
            }

        }
    }

}
