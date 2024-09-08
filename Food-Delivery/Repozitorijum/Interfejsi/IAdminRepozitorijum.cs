using DostavaHrane.Dto;
using DostavaHrane.Entiteti;

namespace DostavaHrane.Repozitorijum.Interfejsi
{
    public interface IAdminRepozitorijum : IRepozitorijum<Korisnik>
    {
        Task<Korisnik> VratiAdminaSaEmailom(KorisnikLoginDto adminDto);
    }
}
