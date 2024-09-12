using DostavaHrane.Entiteti;

namespace DostavaHrane.AplikacioniSloj.Interfejsi
{
    public interface IAdresaServis
    {
        Task DodajAdresuAsync(Adresa adresa);
        Task IzmeniAdresuAsync(Adresa adresa);
        Task<Adresa> VratiAdresuPoIdAsync(int adresaId);
        Task<IEnumerable<Adresa>> VratiSveAdreseZaMusteriju(int musterijaId);
    }
}
