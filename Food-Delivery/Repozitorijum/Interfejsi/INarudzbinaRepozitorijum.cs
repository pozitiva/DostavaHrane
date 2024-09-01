using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;

namespace DostavaHrane.Repozitorijum.Interfejsi
{
    public interface INarudzbinaRepozitorijum : IRepozitorijum<Narudzbina>
    {
        Task DodajStavkuNarudzbineAsync(StavkaNarudzbine stvakaNarudzbine);
        Task<Jelo> VratiJelaPoId(int jeloId);
        Task<Dostavljac> VratiPoIdDostavljacaAsync(int dostavljacId);
        Task<IEnumerable<Narudzbina>> VratiSveNarudzbinePoRestoranuAsync( int restoranId);
    }
}
