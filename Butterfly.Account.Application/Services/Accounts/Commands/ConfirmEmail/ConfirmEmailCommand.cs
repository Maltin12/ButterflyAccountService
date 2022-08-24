using AutoMapper;
using Butterfly.Account.Application.Interfaces.Mappings;
using Butterfly.Account.Domain.Entities;
using MediatR;

namespace Butterfly.Account.Application.Services.Accounts.Commands.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest<ConfirmEmailModel>, ICustomMappings
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<ConfirmEmailCommand, User>()
                .ForMember(domain => domain.IsFirstTime, options => options.MapFrom(value => true));
        }
    }
}