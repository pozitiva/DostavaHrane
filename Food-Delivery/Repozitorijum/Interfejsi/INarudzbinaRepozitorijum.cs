using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;

namespace DostavaHrane.Repozitorijum.Interfejsi
{
    public interface INarudzbinaRepozitorijum : IRepozitorijum<Narudzbina>
    {
        Task AzurirajDostavljacaAsync(Dostavljac dostavljac);
        Task DodajStavkuNarudzbineAsync(StavkaNarudzbine stvakaNarudzbine);
        Task<Dostavljac> VratiDostavljacaPoIdAsync(int? dostavljacId);
        Task<Jelo> VratiJelaPoId(int jeloId);
        
        Task<Dostavljac> VratiSlobodnogDostavljacaAsync();
        Task<IEnumerable<Narudzbina>> VratiSveNarudzbinePoRestoranuAsync( int restoranId);
    }
}
