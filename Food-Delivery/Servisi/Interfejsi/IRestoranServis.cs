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
        // Task VratiJeloPoIdIZaRestoranAsync(int restoranId, int jeloId);
    }
}
