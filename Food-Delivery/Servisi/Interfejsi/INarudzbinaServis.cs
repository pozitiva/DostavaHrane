using DostavaHrane.Dto;
using DostavaHrane.Entiteti;

namespace DostavaHrane.Servisi.Interfejsi
{
    public interface INarudzbinaServis
    {
        Task DodajNarudzbinuAsync(Narudzbina narudzbina);
    }
}
