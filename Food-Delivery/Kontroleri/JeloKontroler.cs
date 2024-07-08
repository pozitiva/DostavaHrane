using DostavaHrane.Entiteti;
using DostavaHrane.Servisi.Interfejsi;
using DostavaHrane.Servisi;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DostavaHrane.Dto;
using System.Diagnostics.Metrics;

namespace DostavaHrane.Kontroleri
{
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
        public async Task<IActionResult> VratiSvaJela()
        {

            var jela = await _jeloServis.VratiSvaJelaAsync();
            var jelaDto = _mapper.Map<List<JeloDto>>(jela);

            return Ok(jelaDto);
        }

        

        [HttpPost]
        public async Task<IActionResult> KreirajJelo(JeloDto jeloDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jelo = _mapper.Map<Jelo>(jeloDto);

            await _jeloServis.DodajJeloAsync(jelo);
           
            return Ok("Jelo je uspesno dodato");
        }

        [HttpPut("{jeloId}")]

        public async Task<IActionResult> IzmeniJelo(int jeloId, [FromBody] JeloDto izmenjenoJelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jelo = await _jeloServis.VratiJeloPoIdAsync(jeloId);

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
