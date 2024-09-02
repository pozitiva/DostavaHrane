using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;

namespace DostavaHrane.Repozitorijum.Interfejsi
{
    public interface IJeloRepozitorijum : IRepozitorijum<Jelo>
    {
        Task<IEnumerable<Jelo>> VratiSvaJelaPoRestoranu(int restoranId);
        Task<IEnumerable<Jelo>> VratiSveAsync();
    }
}
