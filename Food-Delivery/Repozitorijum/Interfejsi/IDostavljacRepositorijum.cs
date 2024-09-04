using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;

namespace DostavaHrane.Repozitorijum.Interfejsi
{
    public interface IDostavljacRepositorijum : IRepozitorijum<Dostavljac>
    {
        Task AzurirajDostavljacaAsync(Dostavljac dostavljac);
        Task<Dostavljac> VratiSlobodnogDostavljacaAsync();
    }
}
