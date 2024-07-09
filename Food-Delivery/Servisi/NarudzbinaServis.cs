using AutoMapper;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using DostavaHrane.Servisi.Interfejsi;

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
    }
}
