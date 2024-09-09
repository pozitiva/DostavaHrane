using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;

namespace DostavaHrane.Repozitorijum.Interfejsi
{
    public interface IDostavljacRepozitorijum : IRepozitorijum<Dostavljac>
    {
        Task AzurirajDostavljacaAsync(Dostavljac dostavljac);
        Task<Dostavljac> VratiDostavljacaPoIdAsync(int? dostavljacId);
        Task<Dostavljac> VratiSlobodnogDostavljacaAsync();
    }
}
