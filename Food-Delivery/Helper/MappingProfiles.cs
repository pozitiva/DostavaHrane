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

            CreateMap<Narudzbina, NarudzbinaDto>();
            CreateMap<NarudzbinaDto, Narudzbina>();

            CreateMap<Adresa, AdresaDto>();
            CreateMap<AdresaDto, Adresa>();

            CreateMap<Musterija, MusterijaDto>();   

        }
    }
}
