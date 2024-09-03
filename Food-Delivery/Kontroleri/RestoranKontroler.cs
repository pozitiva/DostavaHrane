using AutoMapper;
using DostavaHrane.Dto;
using DostavaHrane.Filteri;
using DostavaHrane.Servisi.Interfejsi;
using Microsoft.AspNetCore.Mvc;

namespace DostavaHrane.Kontroleri
{
    [AutorizacioniFilter]
    [Route("api/restoran")]
    [ApiController]
    public class RestoranKontroler : ControllerBase
    {
        private readonly IRestoranServis _restoranServis;
        private readonly IMapper _mapper;

        public RestoranKontroler(IRestoranServis restoranServis, IMapper mapper)
        {
            _restoranServis = restoranServis;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> VratiSveRestorane()
        {
            int musterijaId = Convert.ToInt32(HttpContext.Items["Authorization"]);

            var restorani = await _restoranServis.VratiSveRestoraneAsync();
            var restoraniDto = _mapper.Map<List<RestoranDto>>(restorani);

            return Ok(restoraniDto);
        }


        [HttpGet("{restoranId}")]
        public async Task<IActionResult> VratiRestoranPoId(int restoranId)
        {
            int musterijaId = Convert.ToInt32(HttpContext.Items["Authorization"]);

            var restoran = await _restoranServis.VratiRestoranPoIdAsync(restoranId);

            var restoranDto = _mapper.Map<RestoranDto>(restoran);


            return Ok(restoranDto);
        }



        [HttpGet("{restoranId}/jela")]
        public async Task<IActionResult> VratiSvaJelaZaRestoran(int restoranId)
        {
            int musterijaId = Convert.ToInt32(HttpContext.Items["Authorization"]);

            var jela = await _restoranServis.VratiSvaJelaPoRestoranuAsync(restoranId);
            var jelaDto = _mapper.Map<List<JeloDto>>(jela);

            return Ok(jelaDto);


        }

       

        //[HttpGet("{restoranId}/jela/{jeloId}")]
        //public async Task<IActionResult> VratiJeloZaRestoran(int restoranId, int jeloId)
        //{
        //    var restoran = await _restoranServis.VratiRestoranPoIdAsync(restoranId);
        //    if (restoran == null)
        //    {
        //        return NotFound("Restoran nije pronađen");
        //    }

        //    //var jelo = await _restoranServis.VratiJeloPoIdIZaRestoranAsync(restoranId, jeloId);
        //    if (jelo == null)
        //    {
        //        return NotFound("Jelo nije pronađeno u ovom restoranu");
        //    }

        //    var jeloDto = _mapper.Map<JeloDto>(jelo);
        //    return Ok(jeloDto);
        //}





    }
}