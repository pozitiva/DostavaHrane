using DostavaHrane.Entiteti;

namespace DostavaHrane.Servisi.Interfejsi
{
    public interface IMusterijaServis
    {
        Task<IEnumerable<Musterija>> VratiSveMusterijaAsync();
        Task<Musterija> VratiSveMusterijePoIdAsync();
        Task<Musterija> DodajMusterijuAsync();
        Task<Musterija> IzmeniMusterijuAsync();
        Task ObrisiMusterijuAsync();

        Task<string> RegistrujMusterijuAsync(RegistracijaZahtev zahtev);

       
    }
}
