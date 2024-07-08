using DostavaHrane.Data;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using Microsoft.EntityFrameworkCore;

namespace DostavaHrane.Repozitorijum
{
    public class RestoranRepozitorijum : IRestoranRepozitorijum
    {
        private readonly DataContext _context;
        public RestoranRepozitorijum(DataContext context)
        {
            _context= context;
        }
        public Task DodajAsync(Restoran entity)
        {
            throw new NotImplementedException();
        }

        public Task IzmeniAsync(Restoran restoran)
        {
            throw new NotImplementedException();
        }

        public Task ObrisiAsync(Restoran restoran)
        {
            throw new NotImplementedException();
        }

        public async Task<Restoran> VratiPoIdAsync(int id)
        {
            return await _context.Restorani.Where(r=> r.Id==id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Jelo>> VratiSvaJelaPoRestoranuAsync(int restoranId)
        {
            return await _context.Jela.Where(e=> e.Restoran.Id== restoranId).ToListAsync();
        }

        public async Task<IEnumerable<Restoran>> VratiSveAsync()
        {
            return await _context.Restorani.ToListAsync();
        }
    }
}
