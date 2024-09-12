using DostavaHrane.Entiteti;

namespace DostavaHrane.Interfejsi
{
    public interface IAdresaRepozitorijum : IRepozitorijum<Adresa>
    {
        Task<IEnumerable<Adresa>> VratiSveAdreseZaMusteriju(int musterijaId);
    }
}
