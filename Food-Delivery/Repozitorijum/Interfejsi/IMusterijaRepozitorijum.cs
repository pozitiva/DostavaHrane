using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;

namespace DostavaHrane.Repozitorijum.Interfejsi
{
    public interface IMusterijaRepozitorijum : IRepozitorijum<Musterija>
    {
        Task<bool> ProveraEmailaAsync(string email);
        Task<Musterija> VratiMusterijuSaEmailom(KorisnikLoginDto musterija);
        Task<IEnumerable<Adresa>> VratiSveAdresePoMusterijiAsync(int musterijaId);
    }
}
