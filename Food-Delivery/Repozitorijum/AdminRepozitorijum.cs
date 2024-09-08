using DostavaHrane.Data;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using Microsoft.EntityFrameworkCore;


namespace DostavaHrane.Repozitorijum
{
    public class AdminRepozitorijum : IAdminRepozitorijum
    {
        private readonly DataContext _context;

        public AdminRepozitorijum(DataContext context)
        {
            _context = context;
        }

        public Task DodajAsync(Korisnik entity)
        {
            throw new NotImplementedException();
        }

        public Task IzmeniAsync(Korisnik entity)
        {
            throw new NotImplementedException();
        }

        public Task ObrisiAsync(Korisnik entity)
        {
            throw new NotImplementedException();
        }

        public Task<Korisnik> VratiPoIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Korisnik> VratiAdminaSaEmailom(KorisnikLoginDto admin)
        {
            return await _context.Korisnici
                         .Where(u => u.Email == admin.Email && u.TipKorisnika == "admin")
                         .FirstOrDefaultAsync();
        }
    }
}
