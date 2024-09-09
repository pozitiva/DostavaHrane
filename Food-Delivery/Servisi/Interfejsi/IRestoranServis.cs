using DostavaHrane.Dto;
using DostavaHrane.Entiteti;

namespace DostavaHrane.Servisi.Interfejsi
{
    public interface IRestoranServis
    {
        Task<IEnumerable<Jelo>> VratiSvaJelaPoRestoranuAsync(int id);
        Task<IEnumerable<Restoran>> VratiSveRestoraneAsync();
        Task<Restoran> VratiRestoranPoIdAsync(int id);
        Task<Restoran> UlogujRestoranAsync(KorisnikLoginDto restoranDto);

        Task<IEnumerable<Restoran>> PretraziRestorane(string naziv, string tip);
        Task DodajRestoranAsync(Restoran restoran, IFormFile slika);
        Task obradiKreiranjeRestorana(IFormFile slika, string ime, string opis, string email, string sifra);
    }
}
