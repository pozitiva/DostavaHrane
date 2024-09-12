using DostavaHrane.Entiteti;

namespace DostavaHrane.Interfejsi
{
    public interface IRestoranRepozitorijum : IRepozitorijum<Restoran>
    {
        Task<Restoran> VratiRestoranSaEmailom(Korisnik restoran);
        Task<IEnumerable<Jelo>> VratiSvaJelaPoRestoranuAsync(int restoranId);
        Task<IEnumerable<Restoran>> VratiSveAsync();
        Task<IEnumerable<Restoran>> PretraziRestorane(string naziv, string tip);
    }
}
