using DostavaHrane.Data;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using Microsoft.EntityFrameworkCore;

namespace DostavaHrane.Repozitorijum
{
    public class JeloRepozitorijum : IJeloRepozitorijum
    {
        private readonly DataContext _context;

        public JeloRepozitorijum(DataContext context)
        {
            _context= context;
        }
        public async Task DodajAsync(Jelo jelo)
        {
            _context.Jela.Add(jelo);
            await _context.SaveChangesAsync();
        }

        public async Task IzmeniAsync(Jelo jelo)
        {
            _context.Jela.Update(jelo);
            await _context.SaveChangesAsync();
        }

        public async Task ObrisiAsync(Jelo jelo)
        {
            _context.Jela.Remove(jelo);
            await _context.SaveChangesAsync();
        }

        public async Task<Jelo> VratiPoIdAsync(int id)
        {
            return await _context.Set<Jelo>().FindAsync(id);
        }

        public async Task<IEnumerable<Jelo>> VratiSveAsync()
        {
            return await _context.Jela.ToListAsync();
        }
    }
}
