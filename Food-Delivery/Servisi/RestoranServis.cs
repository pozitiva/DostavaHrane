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
        private readonly IRestoranRepozitorijum _restoranRepozitorijum;
        private readonly IMapper _mapper;
        public RestoranServis(IRestoranRepozitorijum restoranRepozitorijum, IMapper mapper)
        {
            _restoranRepozitorijum = restoranRepozitorijum;
            _mapper = mapper;
        }

        public async Task<Restoran> UlogujRestoranAsync(KorisnikLoginDto restoran)
        {
           Restoran noviRestoran = await _restoranRepozitorijum.VratiRestoranSaEmailom(restoran);

            if (!VerifyPasswordHash(restoran.Sifra, noviRestoran.SifraHash, noviRestoran.SifraSalt))
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
            return await _restoranRepozitorijum.VratiPoIdAsync(id);
        }

        public async Task<IEnumerable<Jelo>> VratiSvaJelaPoRestoranuAsync(int id)
        {
            return await _restoranRepozitorijum.VratiSvaJelaPoRestoranuAsync(id);
        }

        public async Task<IEnumerable<Restoran>> VratiSveRestoraneAsync()
        {
            return await _restoranRepozitorijum.VratiSveAsync();
        }

        public async Task<IEnumerable<Restoran>> PretraziRestoranePoNazivu(string naziv)
        {
            return await _restoranRepozitorijum.PretraziRestoranePoNazivu(naziv);
        }
    }
}