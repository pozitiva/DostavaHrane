using DostavaHrane.Entiteti;

namespace DostavaHrane.Interfejsi
{
    public interface IDostavljacRepozitorijum : IRepozitorijum<Dostavljac>
    {
        Task AzurirajDostavljacaAsync(Dostavljac dostavljac);
        Task<Dostavljac> VratiDostavljacaPoIdAsync(int? dostavljacId);
        Task<Dostavljac> VratiSlobodnogDostavljacaAsync();
    }
}
