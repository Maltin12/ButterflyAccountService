using Butterfly.Account.Application.Interfaces;
using Butterfly.Account.Application.Models;
using Butterfly.Account.Domain.Entities;
using Butterfly.Account.Domain.Enums;
using MediatR;
using visionagency.Butterfly.Account.Application.Interfaces;

namespace Butterfly.Account.Application.Services.Accounts.Commands.Login
{
    public class LoginEmailNotificationHandler : INotificationHandler<LoginEmailNoification>
    {
        private readonly IEmailService _emailSerivce;
        private readonly IAccountDbContext _context;
        public LoginEmailNotificationHandler(IEmailService emailService,
            IAccountDbContext context)
        {
            _emailSerivce = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task Handle(LoginEmailNoification notification, CancellationToken cancellationToken)
        {
            var template = PrepareTemplate(notification, _context.EmailTemplates.FirstOrDefault(x => x.Id == EmailTemplateTypes.WelcomeEmail));

            var emailModel = new EmailModel
            {
                IsHtmlBody = true,
                Content = template.Content,
                Receiver = notification.Email,
                Subject = template.Title
            };
            await _emailSerivce.Send(emailModel);
        }
        private EmailTemplate PrepareTemplate(LoginEmailNoification notification, EmailTemplate emailTemplate)
        {
            IDictionary<string, string> placeholders = new Dictionary<string, string>()
            {
                {"<#FIRSTNAME#>", notification.FirstName },
                {"<#LASTNAME#>", notification.LastName }
            };

            foreach (var placeholder in placeholders)
            {
                emailTemplate.Content = emailTemplate.Content.Replace(placeholder.Key, placeholder.Value);
            }

            return emailTemplate;
        }
    }
}
