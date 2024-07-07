using Azure.Core;
using DostavaHrane.Data;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using Microsoft.EntityFrameworkCore;

namespace DostavaHrane.Repozitorijum
{
    public class Musterijarepozitorijum : IMusterijaRepozitorijum
    {
        private readonly DataContext _context;

        public Musterijarepozitorijum(DataContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Musterija musterija)
        {
            _context.Musterije.Add(musterija);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Musterija>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Musterija> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ProveraEmailaAsync(string email)
        {
            return await _context.Musterije.AnyAsync(m => m.Email == email);
        }

        public Task UpdateAsync(Musterija entity)
        {
            throw new NotImplementedException();
        }
    }
}
