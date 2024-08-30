using AutoMapper;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using DostavaHrane.Servisi.Interfejsi;

namespace DostavaHrane.Servisi
{
    public class RestoranServis : IRestoranServis
    {
        private readonly IRestoranRepozitorijum _restoranRepozitorijum;
        private readonly IMapper _mapper;
        public RestoranServis(IRestoranRepozitorijum restoranRepozitorijum, IMapper mapper)
        {
            _restoranRepozitorijum = restoranRepozitorijum;
            _mapper = mapper;
        }
        public async Task<Restoran> VratiRestoranPoIdAsync(int id)
        {
            return await _restoranRepozitorijum.VratiPoIdAsync(id);
        }

        public async Task<IEnumerable<Jelo>> VratiSvaJelaPoRestoranuAsync(int id)
        {
            return await _restoranRepozitorijum.VratiSvaJelaPoRestoranuAsync(id);
        }

        public async Task<IEnumerable<Restoran>> VratiSveRestoraneAsync()
        {
            return await _restoranRepozitorijum.VratiSveAsync();
        }
    }
}