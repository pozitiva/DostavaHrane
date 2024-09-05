using DostavaHrane.Dto;
using DostavaHrane.Entiteti;

namespace DostavaHrane.Repozitorijum.Interfejsi
{
    public interface IRestoranRepozitorijum : IRepozitorijum<Restoran>
    {
        Task<Restoran> VratiRestoranSaEmailom(KorisnikLoginDto restoran);
        Task<IEnumerable<Jelo>> VratiSvaJelaPoRestoranuAsync(int restoranId);
        Task<IEnumerable<Restoran>> VratiSveAsync();
        Task<IEnumerable<Restoran>> PretraziRestorane(string naziv, string tip);
    }
}
