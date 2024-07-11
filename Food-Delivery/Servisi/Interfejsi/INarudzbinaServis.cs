using DostavaHrane.Dto;
using DostavaHrane.Entiteti;

namespace DostavaHrane.Servisi.Interfejsi
{
    public interface INarudzbinaServis
    {
        Task DodajNarudzbinuAsync(int jeloId, Narudzbina narudzbina);
        Task IzmeniNarudzbinuAsync(Narudzbina narudzbina);
        Task<Narudzbina> VratiNarudzbinuPoIdAsync(int id);
    }
}
