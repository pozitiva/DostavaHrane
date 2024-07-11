using DostavaHrane.Dto;
using DostavaHrane.Entiteti;

namespace DostavaHrane.Servisi.Interfejsi
{
    public interface INarudzbinaServis
    {
        Task DodajNarudzbinuAsync(Narudzbina narudzbina);
        Task IzmeniNarudzbinuAsync(Narudzbina narudzbina);
        Task<Dostavljac> VratiDostavljacaPoIdAsync(int dostavljacId);
        Task<Narudzbina> VratiNarudzbinuPoIdAsync(int narudzbinaId);
    }
}
