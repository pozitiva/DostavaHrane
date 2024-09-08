using AutoMapper;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum;
using DostavaHrane.Repozitorijum.Interfejsi;
using DostavaHrane.Servisi.Interfejsi;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DostavaHrane.Servisi
{
    public class NarudzbinaServis : INarudzbinaServis
    {
        private readonly IUnitOfWork uow;


        public NarudzbinaServis(IUnitOfWork unitOfWork)
        {
           uow= unitOfWork;
            
        }

        public async Task AžurirajDostavljacaAsync(Dostavljac dostavljac)
        {
            await uow.NarudzbinaRepozitorijum.AzurirajDostavljacaAsync(dostavljac);
            await uow.SaveChanges();
        }

        public async Task<Dostavljac> VratiSlobodnogDostavljacaAsync()
        {
            return await uow.NarudzbinaRepozitorijum.VratiSlobodnogDostavljacaAsync();
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

        public async Task<Dostavljac> VratiDostavljacaPoIdAsync(int? dostavljacId)
        {
            return await uow.NarudzbinaRepozitorijum.VratiDostavljacaPoIdAsync(dostavljacId);
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

                Dostavljac dostavljac = await VratiSlobodnogDostavljacaAsync();

                if (dostavljac == null)
                {
                    return false;
                }


                narudzbina.Status = "Predato dostavljacu";
                narudzbina.DostavljacId = dostavljac.Id;


                dostavljac.Slobodan = false;
                await AžurirajDostavljacaAsync(dostavljac);
            }
            else if (narudzbina.Status == "Predato dostavljacu")
            {

                Dostavljac dostavljac = await VratiDostavljacaPoIdAsync(narudzbina.DostavljacId);

                if (dostavljac == null)
                {
                    return false;
                }


                narudzbina.Status = "Dostavljeno";
                dostavljac.Slobodan = true;
                dostavljac.BrojDostava++;

                await AžurirajDostavljacaAsync(dostavljac);
                await uow.SaveChanges();
                return true;
            }

            await IzmeniNarudzbinuAsync(narudzbina);
            await uow.SaveChanges();
            return true;
        }
    }
}
