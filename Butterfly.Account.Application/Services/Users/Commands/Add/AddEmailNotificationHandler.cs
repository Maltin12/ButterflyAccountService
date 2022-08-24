using AutoMapper;
using Butterfly.Account.Application.Interfaces;
using Butterfly.Account.Application.Models;
using Butterfly.Account.Domain.Entities;
using Butterfly.Account.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using visionagency.Butterfly.Account.Application.Interfaces;

namespace Butterfly.Account.Application.Services.Users.Commands.Add
{
    public class AddEmailNotificationHandler : INotificationHandler<AddEmailNotification>
    {
        private readonly IEmailService _emailSerivce;
        private readonly IAccountDbContext _context;

        public AddEmailNotificationHandler(IEmailService emailService,
            IAccountDbContext context,
            UserManager<User> userManager,
            IMapper mapper)
        {
            _emailSerivce = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task Handle(AddEmailNotification notification, CancellationToken cancellationToken)
        {
            var template = PrepareTemplate(notification, _context.EmailTemplates.FirstOrDefault(x => x.Id == EmailTemplateTypes.EmailConfirmation));

            var emailModel = new EmailModel
            {
                IsHtmlBody = true,
                Content = template.Content,
                Receiver = notification.Email,
                Subject = template.Title
            };

            await _emailSerivce.Send(emailModel);
        }

        private EmailTemplate PrepareTemplate(AddEmailNotification notification, EmailTemplate emailTemplate)
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
