using DostavaHrane.Entiteti;

namespace DostavaHrane.Interfejsi
{
    public interface IJeloRepozitorijum : IRepozitorijum<Jelo>
    {
        Task<IEnumerable<Jelo>> VratiSvaJelaPoRestoranu(int restoranId);
        Task<IEnumerable<Jelo>> VratiSveAsync();
    }
}
