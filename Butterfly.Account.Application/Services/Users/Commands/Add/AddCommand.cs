using AutoMapper;
using Butterfly.Account.Application.Interfaces.Mappings;
using Butterfly.Account.Domain.Entities;
using MediatR;

namespace Butterfly.Account.Application.Services.Users.Commands.Add
{
    public class AddCommand : IRequest<AddModel>, ICustomMappings
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<AddCommand, User>()
                .ForMember(domain => domain.FirstName, options => options.MapFrom(model => model.FirstName))
                .ForMember(domain => domain.LastName, options => options.MapFrom(model => model.LastName))
                .ForMember(domain => domain.Email, options => options.MapFrom(model => model.Email))
                .ForMember(domain => domain.PhoneNumber, options => options.MapFrom(model => model.PhoneNumber))
                .ForMember(domain => domain.UserName, options => options.MapFrom(model => model.Email))
                .ForMember(domain => domain.NormalizedEmail, options => options.MapFrom(model => model.Email.ToUpper()))
                .ForMember(domain => domain.NormalizedUserName, options => options.MapFrom(model => model.Email.ToUpper()))
                .ForMember(domain => domain.PhoneNumberConfirmed, options => options.MapFrom(value => true))
                .ForMember(domain => domain.IsFirstTime, options => options.MapFrom(value => true));
        }
    }
}