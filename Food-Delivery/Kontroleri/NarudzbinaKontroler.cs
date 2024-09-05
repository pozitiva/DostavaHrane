using AutoMapper;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Filteri;
using DostavaHrane.Servisi;
using DostavaHrane.Servisi.Interfejsi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DostavaHrane.Kontroleri
{
    [Authorize]
    [Route("api/narudzbina")]
    [ApiController]
    public class NarudzbinaKontroler:ControllerBase
    {
        private readonly INarudzbinaServis _narudzbinaServis;
        private readonly IMapper _mapper;

        public NarudzbinaKontroler(INarudzbinaServis narudzbinaServis, IMapper mapper)
        {
            _narudzbinaServis = narudzbinaServis;
            _mapper = mapper;
           
        }

        [HttpPost]
        public async Task<IActionResult> KreirajNarudzbinu( KreiranjeNarudzbineDto narudzbinaDto)
        {
            var musterijaId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value);  // 'sub' claim in JWT

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

        [HttpPut]
        public async Task<IActionResult> IzmeniStatusNarudzbine([FromBody] NarudzbinaDto narudzbinaDto)
        {
            int restoranId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value);

            Narudzbina narudzbina = await _narudzbinaServis.VratiNarudzbinuPoIdAsync(narudzbinaDto.Id);

            if (narudzbina == null) return NotFound("Nije pronađena narudžbina");

            if (narudzbina.Status.Equals("Na cekanju"))
            {
                narudzbina.Status = "U pripremi";
            }
            else if (narudzbina.Status.Equals("U pripremi"))
            {
                
                Dostavljac dostavljac = await _narudzbinaServis.VratiSlobodnogDostavljacaAsync();

                if (dostavljac == null)
                {
                    return NotFound("Nije nađen slobodan dostavljac");
                }

                
                narudzbina.Status = "Predato dostavljacu";
                narudzbina.DostavljacId = dostavljac.Id;

                
                dostavljac.Slobodan = false;
                await _narudzbinaServis.AžurirajDostavljacaAsync(dostavljac);
            }
            else if (narudzbina.Status == "Predato dostavljacu")
            {
                
                Dostavljac dostavljac = await _narudzbinaServis.VratiDostavljacaPoIdAsync(narudzbina.DostavljacId);

                if (dostavljac == null)
                {
                    return NotFound("Dostavljač nije pronađen");
                }

               
                narudzbina.Status = "Dostavljeno";
                dostavljac.Slobodan = true;
                dostavljac.BrojDostava++;

                await _narudzbinaServis.AžurirajDostavljacaAsync(dostavljac);
            }

            // Ažuriranje narudžbine u bazi podataka
            await _narudzbinaServis.IzmeniNarudzbinuAsync(narudzbina);

            return Ok("Status narudžbine je uspešno izmenjen");
        }


        [HttpGet]
        public async Task<IActionResult> VratiSveNarudzbineZaRestoran()
        {
            int restoranId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value);
            var narudzbine = await _narudzbinaServis.VratiSveNarudzbinePoRestoranu(restoranId);

            

            var narudzbineDto = _mapper.Map<List<NarudzbinaDto>>(narudzbine);

            return Ok(narudzbineDto);
        }


        [HttpGet("{narudzbinaId}")]
        public async Task<IActionResult> VratiNarudzbinuPoId(int narudzbinaId)
        {
            int restoranId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value);

            var narudzbina = await _narudzbinaServis.VratiNarudzbinuPoIdAsync(narudzbinaId);

            var narudzbinaDto = _mapper.Map<RestoranDto>(narudzbina);


            return Ok(narudzbinaDto);
        }


    }
}
