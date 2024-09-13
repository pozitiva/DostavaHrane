using DostavaHrane.Dto;
using DostavaHrane.Entiteti;

namespace DostavaHrane.AplikacioniSloj.Interfejsi
{
    public interface IMusterijaServis
    {
        Task<IEnumerable<Musterija>> VratiSveMusterijaAsync();
        Task<Musterija> VratiMusterijuPoIdAsync(int id);
        Task<Musterija> DodajMusterijuAsync();
        Task IzmeniMusterijuAsync(Musterija musterija);
        Task ObrisiMusterijuAsync();
        Task<IEnumerable<Adresa>> VratiSveAdresePoMusterijiAsync(int id);
    }
}
