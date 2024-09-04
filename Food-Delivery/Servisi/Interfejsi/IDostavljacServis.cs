using DostavaHrane.Entiteti;

namespace DostavaHrane.Servisi.Interfejsi
{
    public interface IDostavljacServis
    {
        Task AžurirajDostavljacaAsync(Dostavljac dostavljac);
        Task<Dostavljac> VratiSlobodnogDostavljacaAsync();
    }
}
