using AutoMapper;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using DostavaHrane.Servisi.Interfejsi;
using Microsoft.EntityFrameworkCore;

namespace DostavaHrane.Servisi
{
    public class NarudzbinaServis : INarudzbinaServis
    {
        private readonly INarudzbinaRepozitorijum _narudzbinaRepozitorijum;
        

        public NarudzbinaServis(INarudzbinaRepozitorijum narudzbinaRepozitorijum)
        {
            _narudzbinaRepozitorijum = narudzbinaRepozitorijum;
            
        }
        public async Task DodajNarudzbinuAsync(int jeloId, Narudzbina narudzbina)
        {
            Jelo jelo = await _narudzbinaRepozitorijum.VratiJelaPoId(jeloId);

            var stvakaNarudzbine = new StavkaNarudzbine()
            {
                Jelo = jelo,
                Narudzbina = narudzbina
            };

            await _narudzbinaRepozitorijum.DodajStavkuNarudzbineAsync(stvakaNarudzbine);

            await _narudzbinaRepozitorijum.DodajAsync(narudzbina);
        }

        public async Task IzmeniNarudzbinuAsync(Narudzbina narudzbina)
        {
            await _narudzbinaRepozitorijum.IzmeniAsync(narudzbina);
        }

        public async Task<Narudzbina> VratiNarudzbinuPoIdAsync(int id)
        {
            return await _narudzbinaRepozitorijum.VratiPoIdAsync(id);
        }
    }
}
