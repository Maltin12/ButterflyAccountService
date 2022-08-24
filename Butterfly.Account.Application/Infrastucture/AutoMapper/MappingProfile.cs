using System.Reflection;
using AutoMapper;

namespace Butterfly.Account.Application.Infrastucture.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            LoadStandardMappings();
            LoadCustomMappings();
        }

        private void LoadStandardMappings()
        {
            var mapsFrom = MapperProfileHelper.LoadStandardMappings(Assembly.GetExecutingAssembly());

            foreach (var map in mapsFrom)
            {
                CreateMap(map.Source, map.Destination).ReverseMap();
            }
        }

        private void LoadCustomMappings()
        {
            var mapsFrom = MapperProfileHelper.LoadCustomMappings(Assembly.GetExecutingAssembly());

            foreach (var map in mapsFrom)
            {
                map.CreateMappings(this);
            }
        }
    }
}