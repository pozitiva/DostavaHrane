using AutoMapper;
using DostavaHrane.AplikacioniSloj.Dto;
using DostavaHrane.AplikacioniSloj.Interfejsi;
using DostavaHrane.Dto;
using DostavaHrane.Servisi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DostavaHrane.Kontroleri
{
    [Route("api/musterija")]
    [ApiController]
    public class MusterijaKontroler : ControllerBase
    {
        private readonly IMusterijaServis _musterijaServis;
        private readonly IMapper _mapper;
        public MusterijaKontroler(IMusterijaServis musterijaServis, IMapper mapper)
        {

            _musterijaServis = musterijaServis;
            _mapper = mapper;
        }

        [HttpPut]
        public async Task<IActionResult> IzmeniJelo([FromBody] MusterijaIzmenaDto izmenjenaMusterija)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var musterija = await _musterijaServis.VratiMusterijuPoIdAsync(izmenjenaMusterija.Id);

            if (musterija == null)
            {
                return NotFound("Musterija nije pronađeno");
            }

           _mapper.Map(izmenjenaMusterija, musterija);


             await _musterijaServis.IzmeniMusterijuAsync(musterija);

            return Ok("Musterija je uspešno izmenjena");
        }
    }
}
