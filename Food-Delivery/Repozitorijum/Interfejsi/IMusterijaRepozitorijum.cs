using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;

namespace DostavaHrane.Repozitorijum.Interfejsi
{
    public interface IMusterijaRepozitorijum : IRepozitorijum<Musterija>
    {
        Task<bool> ProveraEmailaAsync(string email);
        Task<Musterija> VratiMusterijuSaEmailom(LoginZahtev zahtev);
    }
}
