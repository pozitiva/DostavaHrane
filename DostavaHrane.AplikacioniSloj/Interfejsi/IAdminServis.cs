using DostavaHrane.Dto;
using DostavaHrane.Entiteti;

namespace DostavaHrane.AplikacioniSloj.Interfejsi
{
    public interface IAdminServis
    {
        Task<Korisnik> UlogujAdminaAsync(KorisnikLoginDto adminDto);
    }
}
