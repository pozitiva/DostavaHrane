using DostavaHrane.Dto;
using DostavaHrane.Entiteti;

namespace DostavaHrane.Servisi.Interfejsi
{
    public interface IDostavljacServis
    {
        Task AžurirajDostavljacaAsync(Dostavljac dostavljac);
        Task<string> KreirajDostavljaca(Dostavljac dostavljacDto);
        Task<Dostavljac> VratiDostavljacaPoIdAsync(int? dostavljacId);
        Task<Dostavljac> VratiSlobodnogDostavljacaAsync();
    }
}
