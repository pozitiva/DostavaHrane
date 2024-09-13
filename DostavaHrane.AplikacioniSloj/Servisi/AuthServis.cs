using AutoMapper;
using DostavaHrane.AplikacioniSloj.Interfejsi;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Interfejsi;
using System.Security.Cryptography;

namespace DostavaHrane.Servisi
{
    public class AuthServis : IAuthServis
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;
        public AuthServis(IUnitOfWork unitOfWork, IMapper mapper)
        {
            uow = unitOfWork;
            _mapper = mapper;

        }

        public async Task<string> RegistrujMusterijuAsync(MusterijaRegistracijaDto musterija)
        {
            if (string.IsNullOrEmpty(musterija.Email) || string.IsNullOrEmpty(musterija.Sifra))
            {
                return null;
            }
            if (await uow.MusterijaRepozitorijum.ProveraEmailaAsync(musterija.Email))
            {
                return "Nalog sa ovim emailom vec postoji!";
            }

            if (musterija.Sifra != musterija.PotvrdjenaSifra)
            {
                return "Unete sifre se ne podudaraju";
            }

            KreirajSifraHash(musterija.Sifra,
                 out byte[] passwordHash,
                 out byte[] passwordSalt);

            var novaMusterija = new Musterija
            {
                Ime = musterija.Ime,
                Email = musterija.Email,
                SifraHash = passwordHash,
                SifraSalt = passwordSalt,
                TipKorisnika = "musterija"

            };


            await uow.MusterijaRepozitorijum.DodajAsync(novaMusterija);
            await uow.SaveChanges();
            return "Uspesna registracija";
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

        public async Task<Musterija> UlogujMusterijuAsync(KorisnikLoginDto musterijaDto)
        {
            var musterija = _mapper.Map<Musterija>(musterijaDto);
            Musterija novaMusterija = await uow.MusterijaRepozitorijum.VratiMusterijuSaEmailom(musterija);

            if (!VerifikujSifru(musterijaDto.Sifra, novaMusterija.SifraHash, novaMusterija.SifraSalt))
            {
                return null;
            }

            return novaMusterija;
        }
        private bool VerifikujSifru(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public async Task<Restoran> UlogujRestoranAsync(KorisnikLoginDto restoranDto)
        {
            var restoran = _mapper.Map<Restoran>(restoranDto);
            Restoran noviRestoran = await uow.RestoranRepozitorijum.VratiRestoranSaEmailom(restoran);

            if (restoran != null && !VerifyPasswordHash(restoranDto.Sifra, noviRestoran.SifraHash, noviRestoran.SifraSalt))
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
    }
}
