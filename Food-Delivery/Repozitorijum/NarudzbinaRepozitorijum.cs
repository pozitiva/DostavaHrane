using DostavaHrane.Data;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;

namespace DostavaHrane.Repozitorijum
{
    public class NarudzbinaRepozitorijum : INarudzbinaRepozitorijum
    {
        private readonly DataContext _context;

        public NarudzbinaRepozitorijum(DataContext context)
        {
            _context= context;
        }
        public async Task DodajAsync(Narudzbina narudzbina)
        {
            _context.Add(narudzbina);
            await _context.SaveChangesAsync();
        }

        public Task IzmeniAsync(Narudzbina entity)
        {
            throw new NotImplementedException();
        }

        public Task ObrisiAsync(Narudzbina entity)
        {
            throw new NotImplementedException();
        }

        public Task<Narudzbina> VratiPoIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Narudzbina>> VratiSveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
