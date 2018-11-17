using System;
using System.Collections.Generic;
using DeanPortfolio.Server.Core;
using System.Net;
using System.Net.Mail;

namespace DeanPortfolio.Server.DAL
{
    public class MailHandler : IMailHandler
    {
        private SmtpClient _mailClient;
        private MailAddress _fromAddress;
        private IDictionary<string, string> _userMails;

        public MailHandler(string fromAddress, string fromName, string fromPassword, Dictionary<string, string> userMails)
        {
            _userMails = userMails;
            _fromAddress = new MailAddress(fromAddress, fromName);
            _mailClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_fromAddress.Address, fromPassword)
            };
        }

        public void SendMail(string message, ExecutionResult data, string toMail)
        {
            try
            {
                toMail = _userMails[toMail];
                var toAddress = new MailAddress(toMail, toMail.Substring(toMail.IndexOf("@")));
                using (var mail = new MailMessage(_fromAddress, toAddress))
                {
                    mail.Subject = "Test";
                    mail.Body = message;
                    _mailClient.Send(mail);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }            
        }
    }
}
