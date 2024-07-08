using Azure.Core;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using DostavaHrane.Servisi.Interfejsi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;


namespace DostavaHrane.Servisi
{
    public class MusterijaServis : IMusterijaServis
    {

        private readonly IMusterijaRepozitorijum _musterijaRepozitorijum;
        public MusterijaServis(IMusterijaRepozitorijum musterijaRepozitorijum)
        {
            _musterijaRepozitorijum= musterijaRepozitorijum;
        }

        public Task<Musterija> DodajMusterijuAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Musterija> IzmeniMusterijuAsync()
        {
            throw new NotImplementedException();
        }

        public Task ObrisiMusterijuAsync()
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<Musterija>> VratiSveMusterijaAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Musterija> VratiMusterijuPoIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> RegistrujMusterijuAsync(RegistracijaZahtev zahtev)
        {
            if (string.IsNullOrEmpty(zahtev.Email) || string.IsNullOrEmpty(zahtev.Sifra))
            {
                return null;
            }
            if (await _musterijaRepozitorijum.ProveraEmailaAsync(zahtev.Email))
            {
                return "Nalog sa ovim emailom vec postoji!";
            }

            if(zahtev.Sifra != zahtev.PotvrdjenaSifra)
            {
                return "Unete sifre se ne podudaraju";
            }

            KreirajSifraHash(zahtev.Sifra,
                 out byte[] passwordHash,
                 out byte[] passwordSalt);

            var musterija = new Musterija
            {
                Email = zahtev.Email,
                SifraHash = passwordHash,
                SifraSalt = passwordSalt,
                VerifikacioniToken = KreirajRandomToken()
            };


            await _musterijaRepozitorijum.DodajAsync(musterija);
            return "Uspesna registracija";
        }

        private string KreirajRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
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

        public async Task<Musterija> UlogujMusterijuAsync(LoginZahtev zahtev)
        {
            Musterija musterija = await _musterijaRepozitorijum.VratiMusterijuSaEmailom(zahtev);

            if (!VerifyPasswordHash(zahtev.Sifra, musterija.SifraHash, musterija.SifraSalt))
            {
                return null;
            }

            return musterija;
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

        System.Threading.Tasks.Task IMusterijaServis.ObrisiMusterijuAsync()
        {
            throw new NotImplementedException();
        }
    }
}
