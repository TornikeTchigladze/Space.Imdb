using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Space.Imdb.Bll.Contracts.Interfaces.Service;
using Space.Imdb.Bll.Contracts.Models.Email;
using Space.Imdb.Infrastructure.Contracts.Models.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.Bll.Service
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly SmtpConfig _smtpConfig;

        public EmailSenderService(IOptions<SmtpConfig> smtpConfigOptions)
        {
            _smtpConfig = smtpConfigOptions.Value;
        }

        public void SendEmail(Email email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(email.From.Name, email.From.Email));
            message.To.Add(new MailboxAddress(email.To.Name, email.To.Email));
            message.Subject = email.Subject;

            message.Body = new TextPart("plain")
            {
                Text = email.Body
            };

            using var client = new SmtpClient();
            client.Connect(_smtpConfig.Host, _smtpConfig.Port, SecureSocketOptions.None);
            client.Send(message);
            client.Disconnect(true);
        }
    }
}
