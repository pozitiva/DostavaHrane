using DostavaHrane.Data;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
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
            await _context.SaveChangesAsync();
        }

        public Task ObrisiAsync(Musterija musterija)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Musterija>> VratiSveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Musterija> VratiPoIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ProveraEmailaAsync(string email)
        {
            return await _context.Musterije.AnyAsync(m => m.Email == email);
        }

        public Task IzmeniAsync(Musterija entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Musterija> VratiMusterijuSaEmailom(MusterijaLoginDto musterija)
        {
            return await _context.Musterije.FirstOrDefaultAsync(u => u.Email == musterija.Email);
        }

        public async Task<IEnumerable<Adresa>> VratiSveAdresePoMusterijiAsync(int musterijaId)
        {
            return await _context.Adrese.Where(e => e.Musterija.Id == musterijaId).ToListAsync();
        }
    }
}
