using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using Food_Delivery.Entiteti;

namespace DostavaHrane.Repozitorijum.Interfejsi
{
    public interface IMusterijaRepozitorijum : IRepository<Musterija>
    {
        Task<bool> ProveraEmailaAsync(string email);
        Task<Musterija> VratiMusterijuSaEmailom(LoginZahtev zahtev);
    }
}
