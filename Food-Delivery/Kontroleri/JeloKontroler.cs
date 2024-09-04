﻿using DostavaHrane.Entiteti;
using DostavaHrane.Servisi.Interfejsi;
using DostavaHrane.Servisi;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DostavaHrane.Dto;
using System.Diagnostics.Metrics;
using DostavaHrane.Filteri;

namespace DostavaHrane.Kontroleri
{
    [AutorizacioniFilter]
    [Route("api/jelo")]
    [ApiController]
    public class JeloKontroler : ControllerBase
    {
        private readonly IJeloServis _jeloServis;
        private readonly IMapper _mapper;

        public JeloKontroler(IJeloServis jeloServis, IMapper mapper)
        {
            _jeloServis = jeloServis;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> VratiSveJelaZaRestoran()
        {
            int restoranId = Convert.ToInt32(HttpContext.Items["Authorization"]);
            var jela = await _jeloServis.VratiSvaJelaPoRestoranu(restoranId);


            var jelaDto = _mapper.Map<List<JeloDto>>(jela);

            return Ok(jelaDto);
        }


        [HttpPost]
        public async Task<IActionResult> KreirajJelo([FromForm] IFormFile slika, [FromForm] string naziv, [FromForm] decimal cena, [FromForm] string tipJela)
        {
            int restoranId = Convert.ToInt32(HttpContext.Items["Authorization"]);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Jelo jelo = new Jelo { Naziv = naziv, Cena = cena, TipJela = tipJela, RestoranId = restoranId };


            await _jeloServis.DodajJeloAsync(jelo, slika);

            return Ok();
        }

        [HttpPut]

        public async Task<IActionResult> IzmeniJelo([FromBody]  JeloDto izmenjenoJelo)

        {
            int restoranId = Convert.ToInt32(HttpContext.Items["Authorization"]);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (izmenjenoJelo.RestoranId != restoranId)
            {
                return Unauthorized();
            }

            var jelo = await _jeloServis.VratiJeloPoIdAsync(izmenjenoJelo.Id);

            if (jelo == null)
            {
                return NotFound("Jelo nije pronađeno");
            }

            _mapper.Map(izmenjenoJelo, jelo);


            await _jeloServis.IzmeniJeloAsync(jelo);

            return Ok("Jelo je uspešno izmenjeno");
        }

        [HttpDelete("{jeloId}")]
        public async Task<IActionResult> ObrisiJelo(int jeloId)
        {
            int restoranId = Convert.ToInt32(HttpContext.Items["Authorization"]);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jelo = await _jeloServis.VratiJeloPoIdAsync(jeloId);

            if (jelo == null)
            {
                return NotFound("Jelo nije pronađeno");
            }

            await _jeloServis.ObrisiJeloAsync(jelo);

            return Ok("Jelo je uspešno obrisano");
        }






    }
}
