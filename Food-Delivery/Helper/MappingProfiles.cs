using AutoMapper;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;

namespace DostavaHrane.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Jelo, JeloDto>();
            CreateMap<JeloDto, Jelo>();
            CreateMap<Restoran, RestoranDto>();

        }
    }
}
