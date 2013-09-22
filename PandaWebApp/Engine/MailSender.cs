using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Properties;

namespace PandaDataAccessLayer.Helpers
{
    public static class MailSender
    {
        /// <summary>
        /// Отправка письма на почтовый ящик C# mail send
        /// </summary>
        /// <param name="smtpServer">Имя SMTP-сервера</param>
        /// <param name="from">Адрес отправителя</param>
        /// <param name="password">пароль к почтовому ящику отправителя</param>
        /// <param name="mailto">Адрес получателя</param>
        /// <param name="caption">Тема письма</param>
        /// <param name="message">Сообщение</param>
        /// <param name="attachFile">Присоединенный файл</param>
        public static void SendMail(string mailto, string caption, string message, string attachFile = null)
        {
            try
            {
                var mail = new MailMessage
                    {
                        From = new MailAddress(Settings.Default.NoReply)
                    };
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                var client = new SmtpClient
                    {
                        Host = Settings.Default.MailServer,
                        Port = 587,
                        EnableSsl = true,
                        Credentials = new NetworkCredential(PandaWebApp.Properties.Settings.Default.MailLogin, PandaWebApp.Properties.Settings.Default.MailPassword),
                        DeliveryMethod = SmtpDeliveryMethod.Network
                    };
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }

        
        public static void SendConfirmation(this DataAccessLayer dataAccessLayer, Guid userId)
        {
            var user = dataAccessLayer.GetById<UserBase>(userId);
            var guid = Guid.NewGuid();
            var confirmToken = Crypt.GetMD5Hash(guid.ToString());

            var link = string.Format("{2}Authorization/Confirmation?userId={0}&token={1}", userId, confirmToken, Settings.Default.SiteAddress);
            var bodyMessage = string.Format("Подтвердите пожалуйста, перейдя по ссылке {0}", link);

            dataAccessLayer.Create(new Confirmation
                {
                    Token = confirmToken, 
                    UserId = userId
                });
         
          /*  SendMail(user.Email, "Подтверждение аккаунта", bodyMessage, null);*/
        }


    }
}
