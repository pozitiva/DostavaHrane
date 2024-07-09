using DostavaHrane.Entiteti;

namespace DostavaHrane.Servisi.Interfejsi
{
    public interface IAdresaServis
    {
        Task DodajAdresuAsync(Adresa adresa);
        Task IzmeniAdresuAsync(Adresa adresa);
        Task ObrisiAdresuAsync(Adresa adresa);
        Task<Adresa> VratiAdresuPoIdAsync(int adresaId);
    }
}
