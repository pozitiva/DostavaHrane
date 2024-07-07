using DostavaHrane.Entiteti;
using DostavaHrane.Repozitorijum.Interfejsi;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Food_Delivery.Kontroleri
{

    [Route("api/[controller]")]
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
            var adrese = await _adresaRepository.GetAllAsync();
            //obradi ove podatke
            return Ok(adrese);
        }

    }
}
