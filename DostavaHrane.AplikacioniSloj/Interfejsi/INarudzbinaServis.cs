using DostavaHrane.AplikacioniSloj.Dto;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;

namespace DostavaHrane.AplikacioniSloj.Interfejsi
{
    public interface INarudzbinaServis
    {
        Task DodajNarudzbinuAsync(Narudzbina narudzbina);
        Task IzmeniNarudzbinuAsync(Narudzbina narudzbina);
        Task<bool> otkaziNarudzbinuAsync(OtkazivanjeNarudzbineDto narudzbinaDto, int korisnikId);
        Task<bool> izmeniStatusNarudzbineAsync(NarudzbinaDto narudzbinaDto);
        Task<Narudzbina> VratiNarudzbinuPoIdAsync(int narudzbinaId);
        Task<IEnumerable<Narudzbina>> VratiSveNarudzbinePoRestoranu(int restoranId);

    }
}
