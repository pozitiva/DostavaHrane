using DostavaHrane.Entiteti;
using DostavaHrane.Interfejsi;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Food_Delivery.Kontroleri
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdresaKontroler :ControllerBase
    {
        private readonly IAdresaRepository _adresaRepository;

        public AdresaKontroler(IAdresaRepository adresaRepository)
        {
            _adresaRepository = adresaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adresa>>> GetAdrese()
        {
            var adrese = await _adresaRepository.GetAllAsync();
            return Ok(adrese);
        }

    }
}
