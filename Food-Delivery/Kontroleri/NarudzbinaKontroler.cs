using AutoMapper;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Filteri;
using DostavaHrane.Servisi.Interfejsi;
using Microsoft.AspNetCore.Mvc;

namespace DostavaHrane.Kontroleri
{
    [AutorizacioniFilter]
    [Route("api/narudzbina")]
    [ApiController]
    public class NarudzbinaKontroler:ControllerBase
    {
        private readonly INarudzbinaServis _narudzbinaServis;
        private readonly IJeloServis _jeloServis;
        private readonly IMapper _mapper;

        public NarudzbinaKontroler(INarudzbinaServis narudzbinaServis, IMapper mapper, IJeloServis jeloServis)
        {
            _narudzbinaServis = narudzbinaServis;
            _mapper = mapper;
            _jeloServis = jeloServis;
        }

        [HttpPost]
        public async Task<IActionResult> KreirajNarudzbinu( KreiranjeNarudzbineDto narudzbinaDto)
        {
            int musterijaId = Convert.ToInt32(HttpContext.Items["Authorization"]);

            var narudzbina = new Narudzbina
            {
                DatumNarudzbine = System.DateTime.Now,
                StavkeNarudzbine = new List<StavkaNarudzbine>(),
                AdresaId = narudzbinaDto.AdresaId,
                MusterijaId= musterijaId,
                RestoranId= narudzbinaDto.RestoranId,
            };

            decimal ukupnaCena = 0;

            foreach (var stavkaDto in narudzbinaDto.StavkeNarudzbine)
            {
                var stavkaNarudzbine = new StavkaNarudzbine
                {
                    JeloId = stavkaDto.JeloId,
                    Kolicina = stavkaDto.Kolicina,
                    Narudzbina = narudzbina 
                };

                narudzbina.StavkeNarudzbine.Add(stavkaNarudzbine);
                ukupnaCena += stavkaDto.Cena * stavkaDto.Kolicina;
            }

            narudzbina.UkupnaCena = ukupnaCena;
            narudzbina.Status = "Na cekanju";

            await _narudzbinaServis.DodajNarudzbinuAsync(narudzbina);

            return Ok("Narudzbina uspesno kreirana");
        }

        [HttpPut("{narudzbinaId}")]
        public async Task<IActionResult> IzmeniStatusNarudzbine(int narudzbinaId, int dostavljacId)
        {
            Narudzbina narudzbina = await _narudzbinaServis.VratiNarudzbinuPoIdAsync(narudzbinaId);

            if (narudzbina == null) return NotFound("Nije pronadjena narudzbina");

            Dostavljac dostavljac = await _narudzbinaServis.VratiDostavljacaPoIdAsync(dostavljacId);
            if (dostavljac == null)
            {
                return NotFound("Nije nadjen dostavljac");
            }
            if (narudzbina.Status.Equals("Na cekanju")){
                narudzbina.Status = "U pripremi";
            }
            else if (narudzbina.Status.Equals("U pripremi"))
            {
                narudzbina.Status = "Predato dostavljacu";
                narudzbina.DostavljacId = dostavljacId;
            }
            else if(narudzbina.Status == "Predato dostavljacu")
            {
                narudzbina.Status = "Dostavljeno";
                dostavljac.BrojDostava++;

            }

            _narudzbinaServis.IzmeniNarudzbinuAsync(narudzbina);

            return Ok("Status narudzbine je uspesno  izmenjen");
        }


        [HttpGet]
        public async Task<IActionResult> VratiSveNarudzbineZaRestoran()
        {
            int restoranId = Convert.ToInt32(HttpContext.Items["Authorization"]);
            var narudzbine = await _narudzbinaServis.VratiSveNarudzbinePoRestoranu(restoranId);

            

            var narudzbineDto = _mapper.Map<List<NarudzbinaDto>>(narudzbine);

            return Ok(narudzbineDto);
        }

    }
}
