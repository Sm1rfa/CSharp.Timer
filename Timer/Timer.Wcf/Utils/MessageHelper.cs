// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageHelper.cs" company="">
//  Helper for sending messages 
// </copyright>
// <summary>
//   Defines the MessageHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Net.Mail;

namespace Timer.Wcf.Utils
{
    /// <summary>
    /// The message helper.
    /// </summary>
    public class MessageHelper
    {
        /// <summary>
        /// The send mail.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="to">
        /// The to.
        /// </param>
        /// <param name="subject">
        /// The subject.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public void SendMail(string from, string to, string subject, string message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                var smtpServer = new SmtpClient("server28.host.bg", 25)
                {
                    Credentials = new System.Net.NetworkCredential("contact@xn----7sbbaidi9evaf.xn--e1a4c", "stoyan1988")
                };

                mail.From = new MailAddress(from);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = message;

                smtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}