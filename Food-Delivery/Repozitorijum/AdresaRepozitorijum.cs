using DostavaHrane.Data;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using Microsoft.EntityFrameworkCore;

namespace DostavaHrane.Repozitorijum
{
    public class AdresaRepozitorijum:IAdresaRepozitorijum
    {

        private readonly DataContext _context;

        public AdresaRepozitorijum(DataContext context)
        {
            _context = context;

        }

        public async Task DodajAsync(Adresa adresa)
        {
            await _context.Adrese.AddAsync(adresa);
            await _context.SaveChangesAsync();
        }

        public async Task ObrisiAsync(Adresa adresa)
        {
            _context.Adrese.Remove(adresa);
            await _context.SaveChangesAsync();
        }

        public async Task<Adresa> VratiPoIdAsync(int id)
        {
            return await _context.Set<Adresa>().FindAsync(id);
        }

        public async Task IzmeniAsync(Adresa adresa)
        {
            _context.Adrese.Update(adresa);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Adresa>> VratiSveAdreseZaMusteriju(int musterijaId)
        {
            return await _context.Adrese
                      .Where(n => n.MusterijaId == musterijaId)
                      .ToListAsync();
        }
    }
}
