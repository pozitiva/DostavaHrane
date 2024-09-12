using AutoMapper;
using DostavaHrane.AplikacioniSloj.Interfejsi;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
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
            var musterijaId = Convert.ToInt32(User.Claims.ElementAt(0).Value);  

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
            int restoranId = Convert.ToInt32(User.Claims.ElementAt(0).Value);

            if(restoranId != narudzbinaDto.RestoranId)
            {
                return Unauthorized();
            }

            bool rezultat = await _narudzbinaServis.izmeniStatusNarudzbineAsync(narudzbinaDto);

            return rezultat? Ok("Status narudžbine je uspešno izmenjen") : BadRequest("Neuspeh");
        }


        [HttpGet]
        public async Task<IActionResult> VratiSveNarudzbineZaRestoran()
        {
            int restoranId = Convert.ToInt32(User.Claims.ElementAt(0).Value);
            var narudzbine = await _narudzbinaServis.VratiSveNarudzbinePoRestoranu(restoranId);

            var narudzbineDto = _mapper.Map<List<NarudzbinaDto>>(narudzbine);

            return Ok(narudzbineDto);
        }


        [HttpGet("{narudzbinaId}")]
        public async Task<IActionResult> VratiNarudzbinuPoId(int narudzbinaId)
        {
            int restoranId = Convert.ToInt32(User.Claims.ElementAt(0).Value);

            var narudzbina = await _narudzbinaServis.VratiNarudzbinuPoIdAsync(narudzbinaId);

            var narudzbinaDto = _mapper.Map<RestoranDto>(narudzbina);


            return Ok(narudzbinaDto);
        }


    }
}
