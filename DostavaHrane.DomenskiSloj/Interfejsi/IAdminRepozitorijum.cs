using DostavaHrane.Entiteti;

namespace DostavaHrane.Interfejsi
{
    public interface IAdminRepozitorijum : IRepozitorijum<Korisnik>
    {
        Task<Korisnik> VratiAdminaSaEmailom(Korisnik adminDto);
    }
}
