using Butterfly.Account.Application.Interfaces;
using Butterfly.Account.Application.Models;
using Butterfly.Account.Domain.Entities;
using Butterfly.Account.Domain.Enums;
using MediatR;
using visionagency.Butterfly.Account.Application.Interfaces;

namespace Butterfly.Account.Application.Services.Accounts.Queries
{
    class ForgotPasswordNotificationEmailHandler : INotificationHandler<ForgotPasswordEmailNotification>
    {
        private readonly IEmailService _emailService;
        private readonly IAccountDbContext _context;

        public ForgotPasswordNotificationEmailHandler(IEmailService emailService, IAccountDbContext context)
        {
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public async Task Handle(ForgotPasswordEmailNotification notification, CancellationToken cancellationToken)
        {
            var template = PrepareTemplate(notification, _context.EmailTemplates.FirstOrDefault(x => x.Id == EmailTemplateTypes.EmailForgotPassword));
           

            var emailModel = new EmailModel
            {
                IsHtmlBody = true,
                Content = template.Content,
                Receiver = notification.Email,
                Subject = template.Title
            };

            await _emailService.Send(emailModel);
        }

        private EmailTemplate PrepareTemplate(ForgotPasswordEmailNotification notification, EmailTemplate emailTemplate)
        {
            IDictionary<string, string> placeholders = new Dictionary<string, string>()
            {
                {"<#FIRSTNAME#>", notification.FirstName },
                {"<#LASTNAME#>", notification.LastName },
                {"<#URL#>", notification.URL }
            };

            foreach (var placeholder in placeholders)
            {
                emailTemplate.Content = emailTemplate.Content.Replace(placeholder.Key, placeholder.Value);
            }

            return emailTemplate;
        }
    }
}
