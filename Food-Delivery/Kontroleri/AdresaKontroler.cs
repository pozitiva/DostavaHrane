using AutoMapper;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
using DostavaHrane.Filteri;
using DostavaHrane.Servisi.Interfejsi;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace DostavaHrane.Kontroleri
{
    [AutorizacioniFilter]
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
            int musterijaId = Convert.ToInt32(HttpContext.Items["Authorization"]);

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
        public async Task<IActionResult> IzmeniAdresu(int adresaId, string nazivAdrese)
        {
            int musterijaId = Convert.ToInt32(HttpContext.Items["Authorization"]);

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
