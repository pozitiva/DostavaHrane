using AutoMapper;
using DostavaHrane.AplikacioniSloj.Interfejsi;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Interfejsi;
using System.Security.Cryptography;


namespace DostavaHrane.Servisi
{
    public class MusterijaServis : IMusterijaServis
    {

        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;
        public MusterijaServis(IUnitOfWork unitOfWork, IMapper mapper)
        {
            uow= unitOfWork;
            _mapper= mapper;
        }

        public Task<Musterija> DodajMusterijuAsync()
        {
            throw new NotImplementedException();
        }

        public async Task IzmeniMusterijuAsync(Musterija musterija)
        {

            await uow.MusterijaRepozitorijum.IzmeniAsync(musterija);
            await uow.SaveChanges();

        }

        public Task ObrisiMusterijuAsync()
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<Musterija>> VratiSveMusterijaAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Musterija> VratiMusterijuPoIdAsync(int id)
        {
            return await uow.MusterijaRepozitorijum.VratiPoIdAsync(id);
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

            if(musterija.Sifra != musterija.PotvrdjenaSifra)
            {
                return "Unete sifre se ne podudaraju";
            }

            KreirajSifraHash(musterija.Sifra,
                 out byte[] passwordHash,
                 out byte[] passwordSalt);

            var novaMusterija = new Musterija
            {
                Ime= musterija.Ime,
                Email = musterija.Email,
                SifraHash = passwordHash,
                SifraSalt = passwordSalt,
                TipKorisnika= "musterija"
                
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

        public async Task<IEnumerable<Adresa>> VratiSveAdresePoMusterijiAsync(int id)
        {
            return await uow.MusterijaRepozitorijum.VratiSveAdresePoMusterijiAsync(id);
        }

    }
}
