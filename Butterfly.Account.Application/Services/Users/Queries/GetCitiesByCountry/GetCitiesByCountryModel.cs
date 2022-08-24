using AutoMapper;
using Butterfly.Account.Application.Interfaces.Mappings;
using Butterfly.Account.Domain.Entities;

namespace Butterfly.Account.Application.Services.Users.Queries.GetCitiesByCountry
{
    public class GetCitiesByCountryModel : ICustomMappings
    {
        public string Name { get; set; }
        public int ZipCode { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<City, GetCitiesByCountryModel>()
                .ForMember(x => x.Name, options => options.MapFrom(x => x.Name))
                .ForMember(x => x.ZipCode, options => options.MapFrom(x => x.ZipCode));
        }
    }
}