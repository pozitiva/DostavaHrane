using AutoMapper;
using DostavaHrane.Dto;
using DostavaHrane.Servisi;
using DostavaHrane.Servisi.Interfejsi;
using Microsoft.AspNetCore.Mvc;

namespace DostavaHrane.Kontroleri
{

    [Route("api/korisnik")]
    [ApiController]
    public class KorisnikKontroler:ControllerBase
    {
        private readonly IRestoranServis _restoranServis;
        private readonly IMusterijaServis _musterijaServis;
        private readonly IMapper _mapper;

        public KorisnikKontroler(IMusterijaServis musterijaServis, IRestoranServis restoranServis, IMapper mapper)
        {
            _musterijaServis = musterijaServis;
            _restoranServis = restoranServis;
            _mapper = mapper;

        }

        [HttpPost("musterija/register")]
        public async Task<IActionResult> MusterijaRegistracija(MusterijaRegistracijaDto musterijaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var musterija = _mapper.Map<Musterija>(musterijaDto);

            string rezultat = await _musterijaServis.RegistrujMusterijuAsync(musterijaDto);

            if (rezultat == "Nalog sa ovim emailom vec postoji!" || rezultat == "Unete sifre se ne podudaraju")
            {
                return BadRequest(rezultat);
            }

            return Ok("Musterija je uspesno registrovana");
        }


        [HttpPost("musterija/login")]
        public async Task<IActionResult> MusterijaLogin(KorisnikLoginDto musterijaDto)
        {
            var rezultat = await _musterijaServis.UlogujMusterijuAsync(musterijaDto);

            if (rezultat == null)
            {
                return BadRequest("Neuspesno logovanje");
            }

            return Ok(rezultat);
        }


        [HttpPost("restoran/login")]
        public async Task<IActionResult> RestoranLogin(KorisnikLoginDto restoranDto)
        {
            var rezultat = await _restoranServis.UlogujRestoranAsync(restoranDto);

            if (rezultat == null)
            {
                return BadRequest("Neuspesno logovanje");
            }

            return Ok(rezultat);
        }
    }
}
