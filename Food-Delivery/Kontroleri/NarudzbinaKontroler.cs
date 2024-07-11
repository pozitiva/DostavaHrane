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
        public async Task<IActionResult> KreirajNarudzbinu(int jeloId, NarudzbinaDto narudzbinaDto)
        {

            if (narudzbinaDto == null)
                return BadRequest(ModelState);

            var narudzbina = _mapper.Map<Narudzbina>(narudzbinaDto);


            //var stavkeNarudzbine = _mapper.Map<List<StavkaNarudzbine>>(narudzbinaDto.StavkeNarudzbine);

            //var narudzbina = _mapper.Map<Narudzbina>(narudzbinaDto);
            //narudzbina.StavkeNarudzbine = stavkeNarudzbine;

            narudzbina.Status = "U pripremi";
            await _narudzbinaServis.DodajNarudzbinuAsync(jeloId, narudzbina);
            return Ok("Narudzbina uspesno kreirana");
        }

        [HttpPut("{narudzbinaId}")]
        public async Task<IActionResult> IzmeniStatusNarudzbine(int narudzbinaId, int dostavljacId)
        {
            Narudzbina narudzbina = await _narudzbinaServis.VratiNarudzbinuPoIdAsync(narudzbinaId);

            if(narudzbina == null) return BadRequest(ModelState);

            if(narudzbina.Status.Equals("U pripremi"))
            {
                narudzbina.Status = "Predato dostavljacu";
                narudzbina.DostavljacId= dostavljacId;
            }else if(narudzbina.Status == "Predato dostavljacu")
            {
                narudzbina.Status = "Dostavljeno";
            }

            _narudzbinaServis.IzmeniNarudzbinuAsync(narudzbina);

            return Ok("Status narudzbine je uspesno izmenjen");
        }

    }
}
