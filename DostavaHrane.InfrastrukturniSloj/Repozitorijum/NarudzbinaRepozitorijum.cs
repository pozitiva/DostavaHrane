using DostavaHrane.Data;
using DostavaHrane.Entiteti;
using DostavaHrane.Interfejsi;
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
        }

        public async Task DodajStavkuNarudzbineAsync(StavkaNarudzbine stavkaNarudzbine)
        {
            _context.Add(stavkaNarudzbine);
        }

        public async Task IzmeniAsync(Narudzbina narudzbina)
        {
            _context.Update(narudzbina);
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

        public Task<IEnumerable<Narudzbina>> VratiSveAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Narudzbina>> VratiSveNarudzbinePoRestoranuAsync(int restoranId)
        {
            return await _context.Narudzbine
                        .Include(n => n.StavkeNarudzbine)
                        .ThenInclude(s => s.Jelo)
                        .Include(n => n.Musterija)
                        .Include(n => n.Adresa)
                        .Include(n => n.Dostavljac)
                        .Where(n => n.RestoranId == restoranId)
                        .ToListAsync();
        }
    }
}
