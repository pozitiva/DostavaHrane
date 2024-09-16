using DostavaHrane.Data;
using DostavaHrane.Entiteti;
using DostavaHrane.Interfejsi;
using Microsoft.EntityFrameworkCore;

namespace DostavaHrane.Repozitorijum
{
    public class MusterijaRepozitorijum : IMusterijaRepozitorijum
    {
        private readonly DataContext _context;

        public MusterijaRepozitorijum(DataContext context)
        {
            _context = context;
        }
        public async Task DodajAsync(Musterija musterija)
        {
            _context.Musterije.Add(musterija);
            
        }

        public Task ObrisiAsync(Musterija musterija)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Musterija>> VratiSveAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Musterija> VratiPoIdAsync(int id)
        {
            return await _context.Set<Musterija>().FindAsync(id);

        }

        public async Task<bool> ProveraEmailaAsync(string email)
        {
            return await _context.Musterije.AnyAsync(m => m.Email == email);
        }

        public async Task IzmeniAsync(Musterija musterija)
        {
            _context.Musterije.Update(musterija);
        }

        public async Task<Musterija> VratiMusterijuSaEmailom(Korisnik musterija)
        {

            return await _context.Musterije
                     .Include(m => m.Adrese)
                     .Include(m => m.Narudzbine)
                     .ThenInclude(n => n.StavkeNarudzbine)
                     .ThenInclude(s => s.Jelo)
                      .Include(m => m.Narudzbine)
                     .ThenInclude(n => n.Restoran)
                     .Where(u => u.Email == musterija.Email)
                     .FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<Adresa>> VratiSveAdresePoMusterijiAsync(int musterijaId)
        {
            return await _context.Adrese.Where(e => e.Musterija.Id == musterijaId).ToListAsync();
        }


    }
}
