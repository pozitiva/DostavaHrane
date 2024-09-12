using DostavaHrane.Entiteti;

namespace DostavaHrane.Interfejsi
{
    public interface INarudzbinaRepozitorijum : IRepozitorijum<Narudzbina>
    {

        Task DodajStavkuNarudzbineAsync(StavkaNarudzbine stvakaNarudzbine);

        Task<Jelo> VratiJelaPoId(int jeloId);
        Task<IEnumerable<Narudzbina>> VratiSveNarudzbinePoRestoranuAsync(int restoranId);
    }
}
