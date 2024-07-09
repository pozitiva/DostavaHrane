using AutoMapper;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Servisi;
using DostavaHrane.Servisi.Interfejsi;
using Microsoft.AspNetCore.Mvc;

namespace DostavaHrane.Kontroleri
{
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
        public async Task<IActionResult> KreirajNarudzbinu( NarudzbinaDto narudzbinaDto)
        {
            if (narudzbinaDto == null)
                return BadRequest(ModelState);

            var narudzbina = _mapper.Map<Narudzbina>(narudzbinaDto);

            narudzbina.Status = "U pripremi";
            await _narudzbinaServis.DodajNarudzbinuAsync(narudzbina);
            return Ok("Narudzbina uspesno kreirana");
        }

        public async Task<IActionResult> 

    }
}
