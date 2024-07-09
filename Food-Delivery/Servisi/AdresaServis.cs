using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using DostavaHrane.Servisi.Interfejsi;

namespace DostavaHrane.Servisi
{
    public class AdresaServis : IAdresaServis
    {
        private readonly IAdresaRepozitorijum _adresaRepozitorijum;

        public AdresaServis(IAdresaRepozitorijum adresaRepozitorijum)
        {
            _adresaRepozitorijum= adresaRepozitorijum;
        }
        public async Task DodajAdresuAsync(Adresa adresa)
        {
            await _adresaRepozitorijum.DodajAsync(adresa);
        }

        public async Task IzmeniAdresuAsync(Adresa adresa)
        {
            await _adresaRepozitorijum.IzmeniAsync(adresa);
        }

        public Task ObrisiAdresuAsync(Adresa adresa)
        {
            throw new NotImplementedException();
        }

        public async Task<Adresa> VratiAdresuPoIdAsync(int adresaId)
        {
            return await _adresaRepozitorijum.VratiPoIdAsync(adresaId);
        }
    }
}
