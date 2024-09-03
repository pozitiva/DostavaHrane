using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;

namespace DostavaHrane.Repozitorijum.Interfejsi
{
    public interface IAdresaRepozitorijum : IRepozitorijum<Adresa>
    {
        Task<IEnumerable<Adresa>> VratiSveAdreseZaMusteriju(int musterijaId);
    }
}
