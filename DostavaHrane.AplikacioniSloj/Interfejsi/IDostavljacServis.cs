using DostavaHrane.Dto;
using DostavaHrane.Entiteti;

namespace DostavaHrane.AplikacioniSloj.Interfejsi
{
    public interface IDostavljacServis
    {
        Task AžurirajDostavljacaAsync(Dostavljac dostavljac);
        Task<string> KreirajDostavljaca(Dostavljac dostavljacDto);
        Task<Dostavljac> VratiDostavljacaPoIdAsync(int? dostavljacId);
        Task<Dostavljac> VratiSlobodnogDostavljacaAsync();
    }
}
