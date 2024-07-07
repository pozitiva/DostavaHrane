using Azure.Core;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using DostavaHrane.Servisi.Interfejsi;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;


namespace Food_Delivery.Servisi
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

        public Task<Musterija> VratiSveMusterijePoIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> RegistrujMusterijuAsync(RegistracijaZahtev zahtev)
        {
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


            await _musterijaRepozitorijum.AddAsync(musterija);
            return "Uspesna registracija";
        }

        private string KreirajRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

        private void KreirajSifraHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
