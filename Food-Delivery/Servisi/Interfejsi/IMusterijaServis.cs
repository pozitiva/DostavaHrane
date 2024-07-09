using DostavaHrane.Dto;
using DostavaHrane.Entiteti;

namespace DostavaHrane.Servisi.Interfejsi
{
    public interface IMusterijaServis
    {
        Task<IEnumerable<Musterija>> VratiSveMusterijaAsync();
        Task<Musterija> VratiMusterijuPoIdAsync();
        Task<Musterija> DodajMusterijuAsync();
        Task<Musterija> IzmeniMusterijuAsync();
        Task ObrisiMusterijuAsync();

        Task<string> RegistrujMusterijuAsync(MusterijaDto musterija);
        Task<Musterija> UlogujMusterijuAsync(MusterijaLoginDto musterija);

        Task<IEnumerable<Adresa>> VratiSveAdresePoMusterijiAsync(int id);
    }
}
