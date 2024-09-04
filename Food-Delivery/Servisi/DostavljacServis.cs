using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using DostavaHrane.Servisi.Interfejsi;

namespace DostavaHrane.Servisi
{
    public class DostavljacServis : IDostavljacServis
    {
        private readonly IDostavljacRepositorijum _dostavljacRepozitorijum;


        public DostavljacServis(IDostavljacRepositorijum dostavljacRepozitorijum)
        {
            _dostavljacRepozitorijum = dostavljacRepozitorijum;

        }
        public async Task AžurirajDostavljacaAsync(Dostavljac dostavljac)
        {
            await _dostavljacRepozitorijum.AzurirajDostavljacaAsync(dostavljac);
        }

        public async Task<Dostavljac> VratiSlobodnogDostavljacaAsync()
        {
            return await _dostavljacRepozitorijum.VratiSlobodnogDostavljacaAsync();
        }



    }
}
