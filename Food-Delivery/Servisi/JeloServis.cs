using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using DostavaHrane.Servisi.Interfejsi;

namespace DostavaHrane.Servisi
{
    public class JeloServis : IJeloServis
    {
        private readonly IJeloRepozitorijum _jeloRepozitorijum;

        public JeloServis(IJeloRepozitorijum jeloRepozitorijum)
        {
            _jeloRepozitorijum = jeloRepozitorijum;
        }

        public async Task DodajJeloAsync(Jelo jelo)
        {

            await _jeloRepozitorijum.DodajAsync(jelo);
            
        }

        public async Task DodajJeloAsync(Jelo jelo, IFormFile? slika)
        {
            await sacuvajSliku(slika, jelo);

            await _jeloRepozitorijum.DodajAsync(jelo);
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
            await _jeloRepozitorijum.IzmeniAsync(jelo);
        }

        public async Task ObrisiJeloAsync(Jelo jelo)
        {
            await _jeloRepozitorijum.ObrisiAsync(jelo);
        }

        public async Task<Jelo> VratiJeloPoIdAsync(int jeloId)
        {
            return await _jeloRepozitorijum.VratiPoIdAsync(jeloId);
        }

        public async Task<IEnumerable<Jelo>> VratiSvaJelaAsync()
        {
            return await _jeloRepozitorijum.VratiSveAsync();
        }

        public async Task<IEnumerable<Jelo>> VratiSvaJelaPoRestoranu(int restoranId)
        {
           return await _jeloRepozitorijum.VratiSvaJelaPoRestoranu(restoranId);
        }

    }
}
