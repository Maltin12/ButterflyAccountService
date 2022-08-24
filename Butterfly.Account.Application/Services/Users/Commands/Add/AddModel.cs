using AutoMapper;
using Butterfly.Account.Application.Interfaces.Mappings;
using Butterfly.Account.Domain.Entities;

namespace Butterfly.Account.Application.Services.Users.Commands.Add
{
    public class AddModel : ICustomMappings
    {
        public Guid Id { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<User, AddModel>()
                .ForMember(model => model.Id, options => options.MapFrom(domain => domain.Id));
        }
    }
}