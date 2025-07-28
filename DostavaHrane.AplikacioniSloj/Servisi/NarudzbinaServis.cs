using DostavaHrane.AplikacioniSloj.Dto;
using DostavaHrane.AplikacioniSloj.Interfejsi;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Interfejsi;
using Microsoft.EntityFrameworkCore;


namespace DostavaHrane.Servisi
{
    public class NarudzbinaServis : INarudzbinaServis
    {
        private readonly IUnitOfWork uow;
        private readonly IDostavljacServis _dostavljacServis;

        public NarudzbinaServis(IUnitOfWork unitOfWork, IDostavljacServis dostavljacServis)
        {
            uow = unitOfWork;
            _dostavljacServis = dostavljacServis;
        }

        public async Task DodajNarudzbinuAsync(Narudzbina narudzbina)
        {
            await uow.NarudzbinaRepozitorijum.DodajAsync(narudzbina);
            await uow.SaveChanges();
        }

        public async Task IzmeniNarudzbinuAsync(Narudzbina narudzbina)
        {
            await uow.NarudzbinaRepozitorijum.IzmeniAsync(narudzbina);
            await uow.SaveChanges();
        }


        public async Task<Narudzbina> VratiNarudzbinuPoIdAsync(int id)
        {
            return await uow.NarudzbinaRepozitorijum.VratiPoIdAsync(id);
        }


        public async Task<IEnumerable<Narudzbina>> VratiSveNarudzbinePoRestoranu(int restoranId)
        {
            return await uow.NarudzbinaRepozitorijum.VratiSveNarudzbinePoRestoranuAsync(restoranId);
        }


        public async Task<bool> izmeniStatusNarudzbineAsync(NarudzbinaDto narudzbinaDto)
        {
            Narudzbina narudzbinaIzBaze = await VratiNarudzbinuPoIdAsync(narudzbinaDto.Id);

            if (narudzbinaIzBaze == null) return false;
            if (narudzbinaDto.Status == "Dostavljeno")
            {
                if (narudzbinaIzBaze.Status == "Otkazano" && narudzbinaIzBaze.VremeOtkazivanja.HasValue)
                {
                    if (narudzbinaDto.VremeDogadjaja < narudzbinaIzBaze.VremeOtkazivanja.Value)
                    {
                        narudzbinaIzBaze.Status = "Dostavljeno";
                        narudzbinaIzBaze.VremeDostave = narudzbinaDto.VremeDogadjaja;
                    }
                    else
                    {
                        throw new Exception("Konflikt: Nije moguće promeniti status jer je narudžbina već otkazana.");
                    }
                }
                else if (narudzbinaIzBaze.Status != "Dostavljeno")
                {
                    narudzbinaIzBaze.Status = "Dostavljeno";
                    narudzbinaIzBaze.VremeDostave = narudzbinaDto.VremeDogadjaja;
                }
            }
            else
            {
                narudzbinaIzBaze.Status = narudzbinaDto.Status;
            }

            if (narudzbinaDto.Status == "Predato dostavljacu")
            {
                Dostavljac dostavljac = await _dostavljacServis.VratiSlobodnogDostavljacaAsync();

                if (dostavljac == null) return false;
               
                narudzbinaIzBaze.DostavljacId = dostavljac.Id;
                dostavljac.Slobodan = false;
                await _dostavljacServis.AžurirajDostavljacaAsync(dostavljac);
            }

            if (narudzbinaDto.Status == "Dostavljeno" && narudzbinaDto.DostavljacId.HasValue)
            {
                Dostavljac dostavljac = await _dostavljacServis.VratiDostavljacaPoIdAsync(narudzbinaIzBaze.DostavljacId);

                if (dostavljac == null) return false;

                dostavljac.Slobodan = true;
                dostavljac.BrojDostava++;
                await _dostavljacServis.AžurirajDostavljacaAsync(dostavljac);
            }

            await IzmeniNarudzbinuAsync(narudzbinaIzBaze);
            await uow.SaveChanges();
            return true;
        }

        public async Task<bool> otkaziNarudzbinuAsync(OtkazivanjeNarudzbineDto narudzbinaDto, int korisnikId)
        {
            var narudzbinaIzBaze = await uow.NarudzbinaRepozitorijum.VratiPoIdAsync(narudzbinaDto.NarudzbinaId);

            if (narudzbinaIzBaze == null || narudzbinaIzBaze.MusterijaId != korisnikId)  return false;
  
            if (narudzbinaIzBaze.Status == "Dostavljeno" || narudzbinaIzBaze.Status == "Otkazano")  return false;

            narudzbinaIzBaze.Status = "Otkazano";
            narudzbinaIzBaze.VremeOtkazivanja = narudzbinaDto.VremeDogadjaja;
            await IzmeniNarudzbinuAsync(narudzbinaIzBaze);
            await uow.SaveChanges();
            return true;
        }
    }
}
