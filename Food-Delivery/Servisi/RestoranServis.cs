using AutoMapper;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using DostavaHrane.Servisi.Interfejsi;
using System.Security.Cryptography;

namespace DostavaHrane.Servisi
{
    public class RestoranServis : IRestoranServis
    {
        private readonly IUnitOfWork uow;

        private readonly IMapper _mapper;
        public RestoranServis(IUnitOfWork unitOfWork,  IMapper mapper)
        {
            uow = unitOfWork;
            
            _mapper = mapper;
        }

        public async Task<Restoran> UlogujRestoranAsync(KorisnikLoginDto restoran)
        {
            Restoran noviRestoran = await uow.RestoranRepozitorijum.VratiRestoranSaEmailom(restoran);

            if (restoran!=null && !VerifyPasswordHash(restoran.Sifra, noviRestoran.SifraHash, noviRestoran.SifraSalt))
            {
                return null;
            }

            return noviRestoran;
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

        public async Task<Restoran> VratiRestoranPoIdAsync(int id)
        {
            return await uow.RestoranRepozitorijum.VratiPoIdAsync(id);
        }

        public async Task<IEnumerable<Jelo>> VratiSvaJelaPoRestoranuAsync(int id)
        {
            return await uow.RestoranRepozitorijum.VratiSvaJelaPoRestoranuAsync(id);
        }

        public async Task<IEnumerable<Restoran>> VratiSveRestoraneAsync()
        {
            return await uow.RestoranRepozitorijum.VratiSveAsync();
        }

        public async Task<IEnumerable<Restoran>> PretraziRestorane(string naziv, string tip)
        {
            return await uow.RestoranRepozitorijum.PretraziRestorane(naziv, tip);
        }

   
    }
}