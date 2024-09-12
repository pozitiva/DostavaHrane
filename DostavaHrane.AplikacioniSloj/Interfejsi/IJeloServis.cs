using DostavaHrane.Entiteti;
using Microsoft.AspNetCore.Http;

namespace DostavaHrane.AplikacioniSloj.Interfejsi
{
    public interface IJeloServis
    {
        Task<IEnumerable<Jelo>> VratiSvaJelaAsync();
        Task IzmeniJeloAsync(Jelo jelo);
        Task ObrisiJeloAsync(Jelo jelo);
        Task<Jelo> VratiJeloPoIdAsync(int jeloId);
        Task<IEnumerable<Jelo>> VratiSvaJelaPoRestoranu(int restoranId);
        Task DodajJeloAsync(Jelo jelo, IFormFile? slika);
    }
}
