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

            //CreateMap<Narudzbina, NarudzbinaDto

            CreateMap<Narudzbina, NarudzbinaDto>()
           .ForMember(dest => dest.Adresa, opt => opt.MapFrom(src => src.Adresa.Ulica))  
           .ForMember(dest => dest.MusterijaIme, opt => opt.MapFrom(src => src.Musterija.Ime));  

            CreateMap<StavkaNarudzbine, StavkaNarudzbineDto>()
                .ForMember(dest => dest.JeloIme, opt => opt.MapFrom(src => src.Jelo.Naziv));  
           

            CreateMap<NarudzbinaDto, Narudzbina>();

            CreateMap<StavkaNarudzbineDto, StavkaNarudzbine>();

            CreateMap<Adresa, AdresaDto>();
            CreateMap<AdresaDto, Adresa>();

            CreateMap<Musterija, MusterijaDto>();   
            CreateMap<MusterijaDto, Musterija>();

        }
    }
}
