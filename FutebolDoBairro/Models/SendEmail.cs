using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.RegularExpressions;

namespace FutebolDoBairro.Models
{
    public class Email
    {
        public string Provedor { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public Email(string provedor, string username, string password)
        {
            Provedor = provedor ?? throw new ArgumentNullException(nameof(provedor));
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public void SendEmail(List<string>? emailsTo, string subject, string body, List<string>? attachments)
        {
            var message = PrepareteMessage(emailsTo ?? new List<string>(), subject, body, attachments ?? new List<string>());
            SendEmailBySmtp(message);
        }

        private MailMessage PrepareteMessage(List<string> emailsTo, string subject, string body, List<string> attachments)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(Username),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            foreach (var email in emailsTo)
            {
                if (ValidateEmail(email))
                {
                    mail.To.Add(email);
                }
            }

            attachments = attachments ?? new List<string>();
            
            foreach (var file in attachments)
            {
                if (!string.IsNullOrWhiteSpace(file) && System.IO.File.Exists(file))
                {
                    var data = new Attachment(file, MediaTypeNames.Application.Octet);
                    var disposition = data.ContentDisposition;
                    disposition.CreationDate = System.IO.File.GetCreationTime(file!);
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(file!);
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(file!);

                    mail.Attachments.Add(data);
                }
            }

            return mail;
        }

        private bool ValidateEmail(string email)
        {
            Regex expression = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");
            return expression.IsMatch(email);
        }

        private void SendEmailBySmtp(MailMessage message)
        {
            using var smtpClient = new SmtpClient(Provedor)
            {
                Port = 587,
                EnableSsl = true,
                Timeout = 50000,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Username, Password)
            };

            smtpClient.Send(message);
        }
    }
}
