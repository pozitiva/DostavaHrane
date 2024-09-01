using DostavaHrane.Data;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using Microsoft.EntityFrameworkCore;

namespace DostavaHrane.Repozitorijum
{
    public class NarudzbinaRepozitorijum : INarudzbinaRepozitorijum
    {
        private readonly DataContext _context;

        public NarudzbinaRepozitorijum(DataContext context)
        {
            _context = context;
        }
        public async Task DodajAsync(Narudzbina narudzbina)
        {
            _context.Add(narudzbina);
            await _context.SaveChangesAsync();
        }

        public async Task DodajStavkuNarudzbineAsync(StavkaNarudzbine stavkaNarudzbine)
        {
            _context.Add(stavkaNarudzbine);
            await _context.SaveChangesAsync();
        }

        public async Task IzmeniAsync(Narudzbina narudzbina)
        {
            _context.Update(narudzbina);
            await _context.SaveChangesAsync();
        }

        public Task ObrisiAsync(Narudzbina entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Jelo> VratiJelaPoId(int jeloId)
        {
            return await _context.Jela.Where(a => a.Id == jeloId).FirstOrDefaultAsync();
        }

        public async Task<Narudzbina> VratiPoIdAsync(int id)
        {
            return await _context.Set<Narudzbina>().FindAsync(id);
        }

        public async Task<Dostavljac> VratiPoIdDostavljacaAsync(int id)
        {
            return await _context.Set<Dostavljac>().FindAsync(id);
        }

        public async Task<IEnumerable<Narudzbina>> VratiSveNarudzbinePoRestoranuAsync(int restoranId)
        {
            return await _context.Narudzbine
        .Include(n => n.StavkeNarudzbine)
            .ThenInclude(s => s.Jelo)  // Dodaj uključivanje Jela
        .Include(n => n.Musterija)      // Dodaj uključivanje Musterije
        .Include(n => n.Adresa)         // Dodaj uključivanje Adrese
        .Where(n => n.RestoranId == restoranId)
        .ToListAsync();
        }


    }
}
