using AutoMapper;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Servisi;
using DostavaHrane.Servisi.Interfejsi;
using Microsoft.AspNetCore.Mvc;

namespace DostavaHrane.Kontroleri
{
    [Route("api/dostavljac")]
    [ApiController]
    public class DostavljacKontroler:ControllerBase
    {
        private readonly IDostavljacServis _dostavljacServis;
        private readonly IMapper _mapper;
        public DostavljacKontroler(IDostavljacServis dostavljacServis, IMapper mapper)
        {
            _dostavljacServis = dostavljacServis;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> KreirajDostavljaca(DostavljacDto dostavljacDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dostavljac = _mapper.Map<Dostavljac>(dostavljacDto);

            string rezultat = await _dostavljacServis.KreirajDostavljaca(dostavljac);

            return Ok("Dostavljac je uspesno kreiran");
        }

    }
}
