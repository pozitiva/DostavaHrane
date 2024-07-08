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

        public async Task DodajAsync(Adresa entity)
        {
            await _context.Adrese.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task ObrisiAsync(Adresa adresa)
        {
            _context.Adrese.Remove(adresa);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Adresa>> VratiSveAsync()
        {
            return await _context.Adrese.ToListAsync();
        }

        public async Task<Adresa> VratiPoIdAsync(int id)
        {
            return await _context.Adrese.FindAsync(id);
        }

        public async Task IzmeniAsync(Adresa entity)
        {
            _context.Adrese.Update(entity);
            await _context.SaveChangesAsync();
        }


    }
}
