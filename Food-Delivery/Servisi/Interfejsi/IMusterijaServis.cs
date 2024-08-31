using DostavaHrane.Dto;
using DostavaHrane.Entiteti;

namespace DostavaHrane.Servisi.Interfejsi
{
    public interface IMusterijaServis
    {
        Task<IEnumerable<Musterija>> VratiSveMusterijaAsync();
        Task<Musterija> VratiMusterijuPoIdAsync(int id);
        Task<Musterija> DodajMusterijuAsync();
        Task IzmeniMusterijuAsync(Musterija musterija);
        Task ObrisiMusterijuAsync();

        Task<string> RegistrujMusterijuAsync(MusterijaDto musterija);
        //Task<Musterija> UlogujMusterijuAsync(KorisnikLoginDto musterija);

        Task<IEnumerable<Adresa>> VratiSveAdresePoMusterijiAsync(int id);
    }
}
