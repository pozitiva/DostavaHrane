using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using DostavaHrane.Servisi.Interfejsi;

namespace DostavaHrane.Servisi
{
    public class JeloServis : IJeloServis
    {
        private readonly IJeloRepozitorijum _jeloRepozitorijum;

        public JeloServis(IJeloRepozitorijum jeloRepozitorijum)
        {
            _jeloRepozitorijum = jeloRepozitorijum;
        }

        public async Task DodajJeloAsync(Jelo jelo)
        {

            await _jeloRepozitorijum.DodajAsync(jelo);
            
        }

        public async Task IzmeniJeloAsync(Jelo jelo)
        {
            await _jeloRepozitorijum.IzmeniAsync(jelo);
        }

        public async Task ObrisiJeloAsync(Jelo jelo)
        {
            await _jeloRepozitorijum.ObrisiAsync(jelo);
        }

        public async Task<Jelo> VratiJeloPoIdAsync(int jeloId)
        {
            return await _jeloRepozitorijum.VratiPoIdAsync(jeloId);
        }

        public async Task<IEnumerable<Jelo>> VratiSvaJelaAsync()
        {
            return await _jeloRepozitorijum.VratiSveAsync();
        }

    }
}
