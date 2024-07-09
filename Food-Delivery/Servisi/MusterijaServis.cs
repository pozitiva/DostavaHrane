using Azure.Core;
using DostavaHrane.Dto;
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

        public async Task<string> RegistrujMusterijuAsync(MusterijaDto musterija)
        {
            if (string.IsNullOrEmpty(musterija.Email) || string.IsNullOrEmpty(musterija.Sifra))
            {
                return null;
            }
            if (await _musterijaRepozitorijum.ProveraEmailaAsync(musterija.Email))
            {
                return "Nalog sa ovim emailom vec postoji!";
            }

            if(musterija.Sifra != musterija.PotvrdjenaSifra)
            {
                return "Unete sifre se ne podudaraju";
            }

            KreirajSifraHash(musterija.Sifra,
                 out byte[] passwordHash,
                 out byte[] passwordSalt);

            var novaMusterija = new Musterija
            {
                Email = musterija.Email,
                SifraHash = passwordHash,
                SifraSalt = passwordSalt,
                VerifikacioniToken = KreirajRandomToken()
            };


            await _musterijaRepozitorijum.DodajAsync(novaMusterija);
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

        public async Task<Musterija> UlogujMusterijuAsync(MusterijaLoginDto musterija)
        {
            Musterija novaMusterija = await _musterijaRepozitorijum.VratiMusterijuSaEmailom(musterija);

            if (!VerifyPasswordHash(musterija.Sifra, novaMusterija.SifraHash, novaMusterija.SifraSalt))
            {
                return null;
            }

            return novaMusterija;
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

        public async Task<IEnumerable<Adresa>> VratiSveAdresePoMusterijiAsync(int id)
        {
            return await _musterijaRepozitorijum.VratiSveAdresePoMusterijiAsync(id);
        }
    }
}
