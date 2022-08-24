using AutoMapper;
using Butterfly.Account.Application.Interfaces.Mappings;
using Butterfly.Account.Domain.Entities;

namespace Butterfly.Account.Application.Services.Users.Queries.Get
{
    public class GetUserModel : ICustomMappings
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<User, GetUserModel>()
                .ForMember(model => model.FirstName, options => options.MapFrom(domain => domain.FirstName))
                .ForMember(model => model.LastName, options => options.MapFrom(domain => domain.LastName))
                .ForMember(model => model.PhoneNumber, options => options.MapFrom(domain => domain.PhoneNumber))
                .ForMember(model => model.Email, options => options.MapFrom(domain => domain.Email));
        }
    }
}