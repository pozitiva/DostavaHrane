using DostavaHrane.Entiteti;

namespace DostavaHrane.Interfejsi
{
    public interface IMusterijaRepozitorijum : IRepozitorijum<Musterija>
    {
        Task<bool> ProveraEmailaAsync(string email);
        Task<Musterija> VratiMusterijuSaEmailom(Korisnik musterija);
        Task<IEnumerable<Adresa>> VratiSveAdresePoMusterijiAsync(int musterijaId);
    }
}
