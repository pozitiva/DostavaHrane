using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using DostavaHrane.Servisi.Interfejsi;

namespace DostavaHrane.Servisi
{
    public class JeloServis : IJeloServis
    {
        private readonly IUnitOfWork uow;

        public JeloServis(IUnitOfWork unitOfWork)
        {
            uow= unitOfWork;
        }

        public async Task DodajJeloAsync(Jelo jelo)
        {

            await uow.JeloRepozitorijum.DodajAsync(jelo);
            await uow.SaveChanges();

        }

        public async Task DodajJeloAsync(Jelo jelo, IFormFile? slika)
        {
            await sacuvajSliku(slika, jelo);

            await uow.JeloRepozitorijum.DodajAsync(jelo);
            await uow.SaveChanges();
        }

        private async Task sacuvajSliku(IFormFile? slika, Jelo jelo)
        {
            if (slika != null && slika.Length != 0)
            {
                //File.Delete("static/slike/jela/" + jelo.RestoranId + "_" + jelo.Naziv + ".jpg");
                var path = Path.Combine("static/slike/jela", jelo.RestoranId + "_" + jelo.Naziv + ".jpg");

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await slika.CopyToAsync(stream);
                }

                jelo.SlikaUrl = "/static/slike/jela/" + jelo.RestoranId + "_" + jelo.Naziv + ".jpg";
            }
        }

        public async Task IzmeniJeloAsync(Jelo jelo)
        {
            await uow.JeloRepozitorijum.IzmeniAsync(jelo);
            await uow.SaveChanges();
        }

        public async Task ObrisiJeloAsync(Jelo jelo)
        {
            await uow.JeloRepozitorijum.ObrisiAsync(jelo);
            await uow.SaveChanges();
        }

        public async Task<Jelo> VratiJeloPoIdAsync(int jeloId)
        {
            return await uow.JeloRepozitorijum.VratiPoIdAsync(jeloId);
        }

        public async Task<IEnumerable<Jelo>> VratiSvaJelaAsync()
        {
            return await uow.JeloRepozitorijum.VratiSveAsync();
        }

        public async Task<IEnumerable<Jelo>> VratiSvaJelaPoRestoranu(int restoranId)
        {
           return await uow.JeloRepozitorijum.VratiSvaJelaPoRestoranu(restoranId);
        }

    }
}
