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
            int musterijaId = Convert.ToInt32(User.Claims.ElementAt(0).Value);

            var restorani = await _restoranServis.VratiSveRestoraneAsync();
            var restoraniDto = _mapper.Map<List<RestoranDto>>(restorani);

            return Ok(restoraniDto);
        }


        [HttpGet("{restoranId}")]
        public async Task<IActionResult> VratiRestoranPoId(int restoranId)
        {
            int musterijaId = Convert.ToInt32(User.Claims.ElementAt(0).Value);

            var restoran = await _restoranServis.VratiRestoranPoIdAsync(restoranId);

            var restoranDto = _mapper.Map<RestoranDto>(restoran);


            return Ok(restoranDto);
        }



        [HttpGet("{restoranId}/jela")]
        public async Task<IActionResult> VratiSvaJelaZaRestoran(int restoranId)
        {
            int musterijaId = Convert.ToInt32(User.Claims.ElementAt(0).Value);

            var jela = await _restoranServis.VratiSvaJelaPoRestoranuAsync(restoranId);
            var jelaDto = _mapper.Map<List<JeloDto>>(jela);

            return Ok(jelaDto);


        }

        [HttpGet("pretraga")]
        public async Task<IActionResult> PretraziRestoranePoNazivu([FromQuery(Name = "naziv")] string naziv = null, [FromQuery(Name ="tip")] string tip = null)
        {
            int musterijaId = Convert.ToInt32(User.Claims.ElementAt(0).Value);

            var restorani = await _restoranServis.PretraziRestorane(naziv, tip);
            var restoraniDto = _mapper.Map<List<RestoranDto>>(restorani);

            return Ok(restoraniDto);
        }

        [HttpPost]
        public async Task<IActionResult> KreirajRestoran([FromForm] IFormFile slika, [FromForm] string ime, [FromForm] string opis, [FromForm] string email, [FromForm] string sifra)
        {
            //int restoranId = Convert.ToInt32(User.Claims.ElementAt(0).Value);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

             _restoranServis.obradiKreiranjeRestorana(slika, ime, opis, email, sifra);

            return Ok();
        }





    }
}