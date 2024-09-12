using DostavaHrane.AplikacioniSloj.Interfejsi;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Interfejsi;


namespace DostavaHrane.Servisi
{
    public class NarudzbinaServis : INarudzbinaServis
    {
        private readonly IUnitOfWork uow;
        private readonly IDostavljacServis _dostavljacServis;

        public NarudzbinaServis(IUnitOfWork unitOfWork, IDostavljacServis dostavljacServis)
        {
           uow= unitOfWork;
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
            Narudzbina narudzbina = await VratiNarudzbinuPoIdAsync(narudzbinaDto.Id);

            if (narudzbina == null) return false;

            if (narudzbina.Status.Equals("Na cekanju"))
            {
                narudzbina.Status = "U pripremi";
            }
            else if (narudzbina.Status.Equals("U pripremi"))
            {

                Dostavljac dostavljac = await _dostavljacServis.VratiSlobodnogDostavljacaAsync();

                if (dostavljac == null)
                {
                    return false;
                }

                narudzbina.Status = "Predato dostavljacu";
                narudzbina.DostavljacId = dostavljac.Id;

                dostavljac.Slobodan = false;
                await _dostavljacServis.AžurirajDostavljacaAsync(dostavljac);
            }
            else if (narudzbina.Status == "Predato dostavljacu")
            {

                Dostavljac dostavljac = await _dostavljacServis.VratiDostavljacaPoIdAsync(narudzbina.DostavljacId);

                if (dostavljac == null)
                {
                    return false;
                }

                narudzbina.Status = "Dostavljeno";
                dostavljac.Slobodan = true;
                dostavljac.BrojDostava++;

                await _dostavljacServis.AžurirajDostavljacaAsync(dostavljac);
               
               
            }

            await IzmeniNarudzbinuAsync(narudzbina);
            await uow.SaveChanges();
            return true;
        }
    }
}
