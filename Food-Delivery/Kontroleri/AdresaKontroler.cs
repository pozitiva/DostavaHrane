using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace DostavaHrane.Kontroleri
{

    [Route("api/adresa")]
    [ApiController]
    public class AdresaKontroler :ControllerBase
    {
        private readonly IAdresaRepozitorijum _adresaRepository;

        public AdresaKontroler(IAdresaRepozitorijum adresaRepository)
        {
            _adresaRepository = adresaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adresa>>> GetAdrese()
        {
            var adrese = await _adresaRepository.VratiSveAsync();
            //obradi ove podatke
            return Ok(adrese);
        }

    }
}
