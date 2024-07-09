using AutoMapper;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using DostavaHrane.Servisi;
using DostavaHrane.Servisi.Interfejsi;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace DostavaHrane.Kontroleri
{

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
        public async Task<IActionResult> KreirajAdresu(AdresaDto adresaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var adresa = _mapper.Map<Adresa>(adresaDto);

            await _adresaServis.DodajAdresuAsync(adresa);

            return Ok("Adresa je uspesno dodato");
        }

        [HttpPut("{adresaId}")]
        public async Task<IActionResult> IzmeniAdresu(int adresaId, string nazivAdrese)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Adresa adresa = await _adresaServis.VratiAdresuPoIdAsync(adresaId);
            if(adresa == null)
            {
                return NotFound("Adresa nije pronađena");
            }
            adresa.Naziv= nazivAdrese;
            await _adresaServis.IzmeniAdresuAsync(adresa);

            return Ok("Adresa je uspešno izmenjena");
        }

    }
}
