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

        public async Task AddAsync(Adresa entity)
        {
            await _context.Adrese.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Adrese.FindAsync(id);
            _context.Adrese.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Adresa>> GetAllAsync()
        {
            return await _context.Adrese.ToListAsync();
        }

        public async Task<Adresa> GetByIdAsync(int id)
        {
            return await _context.Adrese.FindAsync(id);
        }

        public async Task UpdateAsync(Adresa entity)
        {
            _context.Adrese.Update(entity);
            await _context.SaveChangesAsync();
        }


    }
}
