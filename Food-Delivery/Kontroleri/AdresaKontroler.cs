using AutoMapper;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Filteri;
using DostavaHrane.Servisi;
using DostavaHrane.Servisi.Interfejsi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace DostavaHrane.Kontroleri
{
    [Authorize]
    [Route("api/adresa")]
    [ApiController]
    public class AdresaKontroler : ControllerBase
    {
        private readonly IAdresaServis _adresaServis;
        private readonly IMapper _mapper;

        public AdresaKontroler(IAdresaServis adresaServis, IMapper mapper)
        {
            _adresaServis = adresaServis;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> KreirajAdresu(KreiranjeAdreseDto adresaDto)
        {
            int musterijaId = Convert.ToInt32(User.Claims.ElementAt(0).Value);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var adresa = _mapper.Map<Adresa>(adresaDto);
            adresa.MusterijaId = musterijaId;

            await _adresaServis.DodajAdresuAsync(adresa);

            return Ok("Adresa je uspesno dodato");
        }

        [HttpPut("{adresaId}")]
        public async Task<IActionResult> IzmeniAdresu([FromBody] AdresaDto izmenjenaAdresa)
        {
            int musterijaId = Convert.ToInt32(User.Claims.ElementAt(0).Value);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Adresa adresa = await _adresaServis.VratiAdresuPoIdAsync(izmenjenaAdresa.Id);
            if(adresa == null)
            {
                return NotFound("Adresa nije pronađena");
            }

            _mapper.Map(izmenjenaAdresa, adresa);


            await _adresaServis.IzmeniAdresuAsync(adresa);

            return Ok("Adresa je uspešno izmenjena");
        }

       
        [HttpGet]
        public async Task<IActionResult> VratiSveAdreseZaMusteriju()
        {
            int musterijaId = Convert.ToInt32(User.Claims.ElementAt(0).Value);
            var adrese = await _adresaServis.VratiSveAdreseZaMusteriju(musterijaId);



            var adreseDto = _mapper.Map<List<AdresaDto>>(adrese);

            return Ok(adreseDto);
        }

    }
}
