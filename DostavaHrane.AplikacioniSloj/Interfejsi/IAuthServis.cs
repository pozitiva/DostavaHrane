using DostavaHrane.Dto;
using DostavaHrane.Entiteti;

namespace DostavaHrane.AplikacioniSloj.Interfejsi
{
    public interface IAuthServis
    {
        Task<Korisnik> UlogujAdminaAsync(KorisnikLoginDto adminDto);
        Task<Restoran> UlogujRestoranAsync(KorisnikLoginDto restoranDto);
        Task<string> RegistrujMusterijuAsync(MusterijaRegistracijaDto musterija);
        Task<Musterija> UlogujMusterijuAsync(KorisnikLoginDto musterija);
    }
}
