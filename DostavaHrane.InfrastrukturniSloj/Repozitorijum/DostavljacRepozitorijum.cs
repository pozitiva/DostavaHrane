using DostavaHrane.Data;
using DostavaHrane.Entiteti;
using DostavaHrane.Interfejsi;
using Microsoft.EntityFrameworkCore;

namespace DostavaHrane.Repozitorijum
{
    public class DostavljacRepozitorijum : IDostavljacRepozitorijum
    {
        private readonly DataContext _context;

        public DostavljacRepozitorijum(DataContext context)
        {
            _context = context;
        }

        public async Task AzurirajDostavljacaAsync(Dostavljac dostavljac)
        {
            _context.Dostavljaci.Update(dostavljac);
        }

        public async Task DodajAsync(Dostavljac entity)
        {
            _context.Dostavljaci.Add(entity);
        }

        public Task IzmeniAsync(Dostavljac entity)
        {
            throw new NotImplementedException();
        }

        public Task ObrisiAsync(Dostavljac entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Dostavljac> VratiDostavljacaPoIdAsync(int? dostavljacId)
        {
            return await _context.Set<Dostavljac>().FindAsync(dostavljacId);
        }

        public Task<Dostavljac> VratiPoIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Dostavljac> VratiSlobodnogDostavljacaAsync()
        {
            return await _context.Dostavljaci
            .Where(d => d.Slobodan)
            .FirstOrDefaultAsync();
        }

        public Task<IEnumerable<Dostavljac>> VratiSveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
