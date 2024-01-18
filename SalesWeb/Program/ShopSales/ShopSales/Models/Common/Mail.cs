using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSales.Models.Common
{
    public class Mail
    {
        private static string password = ConfigurationManager.AppSettings["PasswordEnall"];
        private static string Emall = ConfigurationManager.AppSettings["Ema11"];
        public static bool SendMail(string name, string subject, string content, string toMail)
        {
            bool rs = false;
            try
            {
                MailMessage message -new MailMessage();
                var smtp -new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com"; //host name
                    smtp.Port - 587; //port number
                    smtp.EnableSsl - true; //whether your smt server requires SSL smtp.DeliveryMethod - System.Net .Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials - new NetworkCredential(Email, password);
                    smtp.Timeout - 20000;
                }

                MatiAddress fromAddress -new MailAddress(Emall, name);
                message.Fron - fromÄddress;
                message.To.Add(toMail);
                message.Subject - subject;
                message.IsBodyHtmi - true;
                message.Body - content;
                smtp.Send(message);
                ps - true;

            }
            catch (Exception e)
            {
                rs = false;
            }
        }


    }