using System.Net;
using System.Net.Mail;
using Butterfly.Account.Application.Models;
using visionagency.Butterfly.Account.Application.Interfaces;

namespace Butterfly.Account.Infrastucture
{
    public class EmailService : IEmailService
    {
        public async Task Send(EmailModel model)
        {
            SmtpClient client = new SmtpClient("smtp.mailtrap.io", 587);
            client.Credentials = new NetworkCredential("48b7dd91a3adca", "6b90159a785716");

            MailAddress to = new MailAddress(model.Receiver);
            MailAddress from = new MailAddress("maltingerxhaliu@gmail.com");


            MailMessage message = new MailMessage(from, to);
            message.Body = model.Content;
            message.Subject = model.Subject;
            message.IsBodyHtml = model.IsHtmlBody;

            await client.SendMailAsync(message);
        }
    }
}