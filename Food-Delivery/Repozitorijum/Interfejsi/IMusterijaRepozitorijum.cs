using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;

namespace DostavaHrane.Repozitorijum.Interfejsi
{
    public interface IMusterijaRepozitorijum : IRepository<Musterija>
    {
        Task<bool> ProveraEmailaAsync(string email);
    }
}
