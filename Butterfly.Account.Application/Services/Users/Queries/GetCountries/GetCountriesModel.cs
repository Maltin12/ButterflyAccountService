using AutoMapper;
using Butterfly.Account.Application.Interfaces.Mappings;
using Butterfly.Account.Domain.Entities;

namespace Butterfly.Account.Application.Services.Users.Queries.GetCountries
{
    public class GetCountriesModel : ICustomMappings
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Country, GetCountriesModel>()
                .ForMember(model => model.Id, options => options.MapFrom(domain => domain.Id))
                .ForMember(model => model.Name, options => options.MapFrom(domain => domain.Name))
                .ForMember(model => model.Status, options => options.MapFrom(domain => domain.Status));
        }
    }
}