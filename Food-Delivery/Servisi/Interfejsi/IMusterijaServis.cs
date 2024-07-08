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

        Task<string> RegistrujMusterijuAsync(RegistracijaZahtev zahtev);
        Task<Musterija> UlogujMusterijuAsync(LoginZahtev zahtev);
    }
}
