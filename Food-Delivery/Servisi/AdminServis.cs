using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using DostavaHrane.Servisi.Interfejsi;
using System.Security.Cryptography;

namespace DostavaHrane.Servisi
{
    public class AdminServis : IAdminServis
    {
        private readonly IUnitOfWork uow;
        public AdminServis(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        public async Task<Korisnik> UlogujAdminaAsync(KorisnikLoginDto admin)
        {
            Korisnik noviAdmin = await uow.AdminRepozitorijum.VratiAdminaSaEmailom(admin);
            if (!VerifyPasswordHash(admin.Sifra, noviAdmin.SifraHash, noviAdmin.SifraSalt))
            {
                return null;
            }

            return noviAdmin;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
