using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using Microsoft.AspNetCore.Http;


namespace DostavaHrane.AplikacioniSloj.Interfejsi
{
    public interface IRestoranServis
    {
        Task<IEnumerable<Jelo>> VratiSvaJelaPoRestoranuAsync(int id);
        Task<IEnumerable<Restoran>> VratiSveRestoraneAsync();
        Task<Restoran> VratiRestoranPoIdAsync(int id);
        Task<IEnumerable<Restoran>> PretraziRestorane(string naziv, string tip);
        Task obradiKreiranjeRestorana(IFormFile slika, string ime, string opis, string email, string sifra);
    }
}
