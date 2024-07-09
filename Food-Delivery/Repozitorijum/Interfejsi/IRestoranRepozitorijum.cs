using DostavaHrane.Entiteti;

namespace DostavaHrane.Repozitorijum.Interfejsi
{
    public interface IRestoranRepozitorijum : IRepozitorijum<Restoran>
    {
        Task<IEnumerable<Jelo>> VratiSvaJelaPoRestoranuAsync(int restoranId);
        Task<IEnumerable<Restoran>> VratiSveAsync();
    }
}
