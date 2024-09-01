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
        public async Task DodajNarudzbinuAsync(Narudzbina narudzbina)
        {
            await _narudzbinaRepozitorijum.DodajAsync(narudzbina);
        }

        public async Task IzmeniNarudzbinuAsync(Narudzbina narudzbina)
        {
            await _narudzbinaRepozitorijum.IzmeniAsync(narudzbina);
        }

        public async Task<Dostavljac> VratiDostavljacaPoIdAsync(int dostavljacId)
        {
           return await _narudzbinaRepozitorijum.VratiPoIdDostavljacaAsync(dostavljacId);
        }

        public async Task<Narudzbina> VratiNarudzbinuPoIdAsync(int id)
        {
            return await _narudzbinaRepozitorijum.VratiPoIdAsync(id);
        }

        public async Task<IEnumerable<Narudzbina>> VratiSveNarudzbinePoRestoranu(int restoranId)
        {
            return await _narudzbinaRepozitorijum.VratiSveNarudzbinePoRestoranuAsync(restoranId);
        }
    }
}
