using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using DostavaHrane.Servisi.Interfejsi;

namespace DostavaHrane.Servisi
{
    public class AdresaServis : IAdresaServis
    {
        private readonly IUnitOfWork uow;

        public AdresaServis(IUnitOfWork unitOfWork)
        {
            uow=unitOfWork;
        }
        public async Task DodajAdresuAsync(Adresa adresa)
        {
            await uow.AdresaRepozitorijum.DodajAsync(adresa);
            await uow.SaveChanges();
        }

        public async Task IzmeniAdresuAsync(Adresa adresa)
        {
            await uow.AdresaRepozitorijum.IzmeniAsync(adresa);
            await uow.SaveChanges();
        }

 

        public async Task<Adresa> VratiAdresuPoIdAsync(int adresaId)
        {
            return await uow.AdresaRepozitorijum.VratiPoIdAsync(adresaId);
        }

        public async Task<IEnumerable<Adresa>> VratiSveAdreseZaMusteriju(int musterijaId)
        {
            return await uow.AdresaRepozitorijum.VratiSveAdreseZaMusteriju(musterijaId);
        }
    }
}
