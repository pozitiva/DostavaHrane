using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using DostavaHrane.Servisi.Interfejsi;

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

        public async Task<Dostavljac> VratiSlobodnogDostavljacaAsync()
        {
            return await uow.DostavljacRepozitorijum.VratiSlobodnogDostavljacaAsync();
        }



    }
}
