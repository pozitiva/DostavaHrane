using DostavaHrane.AplikacioniSloj.Interfejsi;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Interfejsi;


namespace DostavaHrane.Servisi
{
    public class DostavljacServis : IDostavljacServis
    {
        private readonly IUnitOfWork uow;

        public DostavljacServis(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;

        }
        public async Task AžurirajDostavljacaAsync(Dostavljac dostavljac)
        {
            await uow.DostavljacRepozitorijum.AzurirajDostavljacaAsync(dostavljac);
            await uow.SaveChanges();

        }

        public async Task<string> KreirajDostavljaca(Dostavljac dostavljac)
        {
            await uow.DostavljacRepozitorijum.DodajAsync(dostavljac);
            await uow.SaveChanges();
            return "Uspesna registracija";
        }

        public async Task<Dostavljac> VratiDostavljacaPoIdAsync(int? dostavljacId)
        {
            return await uow.DostavljacRepozitorijum.VratiDostavljacaPoIdAsync(dostavljacId);
        }

        public async Task<Dostavljac> VratiSlobodnogDostavljacaAsync()
        {
            return await uow.DostavljacRepozitorijum.VratiSlobodnogDostavljacaAsync();
        }



    }
}
