using AutoMapper;
using DostavaHrane.AplikacioniSloj.Interfejsi;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Interfejsi;
using System.Security.Cryptography;

namespace DostavaHrane.Servisi
{
    public class AdminServis : IAdminServis
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;
        public AdminServis(IUnitOfWork unitOfWork, IMapper mapper)
        {
            uow = unitOfWork;
            _mapper = mapper;

        }
        public async Task<Korisnik> UlogujAdminaAsync(KorisnikLoginDto adminDto)
        {
            var admin = _mapper.Map<Korisnik>(adminDto);
            Korisnik noviAdmin = await uow.AdminRepozitorijum.VratiAdminaSaEmailom(admin);
            if (!VerifyPasswordHash(adminDto.Sifra, noviAdmin.SifraHash, noviAdmin.SifraSalt))
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
