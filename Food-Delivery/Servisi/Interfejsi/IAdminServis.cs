using DostavaHrane.Dto;
using DostavaHrane.Entiteti;

namespace DostavaHrane.Servisi.Interfejsi
{
    public interface IAdminServis
    {
        Task<Korisnik> UlogujAdminaAsync(KorisnikLoginDto adminDto);
    }
}
