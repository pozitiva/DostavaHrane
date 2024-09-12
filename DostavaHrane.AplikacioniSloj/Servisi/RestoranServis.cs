using AutoMapper;
using DostavaHrane.AplikacioniSloj.Interfejsi;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Interfejsi;
using Microsoft.AspNetCore.Http;
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

        public async Task<Restoran> UlogujRestoranAsync(KorisnikLoginDto restoranDto)
        {
            var restoran = _mapper.Map<Restoran>(restoranDto);
            Restoran noviRestoran = await uow.RestoranRepozitorijum.VratiRestoranSaEmailom(restoran);

            if (restoran!=null && !VerifyPasswordHash(restoranDto.Sifra, noviRestoran.SifraHash, noviRestoran.SifraSalt))
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


        private async Task SacuvajSliku(IFormFile? slika, Restoran restoran)
        {

            if (slika != null && slika.Length != 0)
            {
                var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "DostavaHrane.InfrastrukturniSloj", "Podaci", "static", "slike", "restorani"));
                var path = Path.Combine(basePath, restoran.Ime + ".jpg");

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await slika.CopyToAsync(stream);
                }

                restoran.SlikaUrl = "/static/slike/restorani/" + restoran.Ime + ".jpg";
            }


        }

        public async Task obradiKreiranjeRestorana(IFormFile slika, string ime, string opis, string email, string sifra)
        {
            KreirajSifraHash(sifra,
                 out byte[] passwordHash,
                 out byte[] passwordSalt);

            var novRestoran = new Restoran
            {
                Ime = ime,
                Opis = opis,
                Email = email,
                SifraHash = passwordHash,
                SifraSalt = passwordSalt,
                TipKorisnika = "restoran"
            };

            await SacuvajSliku(slika, novRestoran);
            await uow.RestoranRepozitorijum.DodajAsync(novRestoran);
            await uow.SaveChanges();

        }


        private void KreirajSifraHash(string sifra, out byte[] sifraHash, out byte[] sifraSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                sifraSalt = hmac.Key;
                sifraHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(sifra));
            }
        }

    }


}