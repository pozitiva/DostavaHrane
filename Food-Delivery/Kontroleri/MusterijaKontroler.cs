using Microsoft.AspNetCore.Mvc;
using DostavaHrane.Servisi.Interfejsi;
using AutoMapper;
using DostavaHrane.Dto;
using DostavaHrane.Servisi;

namespace DostavaHrane.Kontroleri
{
    [Route("api/musterija")]
    [ApiController]
    public class MusterijaKontroler : ControllerBase 
    {
 
        private readonly IMusterijaServis _musterijaServis;
        private readonly IMapper _mapper;
        public MusterijaKontroler(IMusterijaServis musterijaServis, IMapper mapper)
        {
            _musterijaServis = musterijaServis;
            _mapper = mapper;

        }


        [HttpPost("register")]
        public async Task<IActionResult> Registracija(MusterijaDto musterijaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var musterija = _mapper.Map<Musterija>(musterijaDto);

            string rezultat = await _musterijaServis.RegistrujMusterijuAsync(musterijaDto);

            if (rezultat == "Nalog sa ovim emailom vec postoji!")
            {
                return BadRequest("Nalog sa ovim emailom vec postoji!");
            }
            else if (rezultat == "Unete sifre se ne podudaraju")
            {
                return BadRequest("Unete sifre se ne podudaraju");
            }

            return Ok("Musterija je uspesno registrovana");
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(MusterijaLoginDto musterijaDto)
        {


            var rezultat = await _musterijaServis.UlogujMusterijuAsync(musterijaDto);

            if(rezultat== null)
            {
                return BadRequest("Neuspesno logovanje");
            }
           

            return Ok("Korisnik je uspesno ulogovan");

        }

        [HttpGet("{musterijaId}/adrese")]
        public async Task<IActionResult> VratiSveAdreseZaMusteriju(int musterijaId)
        {
            var adrese = await _musterijaServis.VratiSveAdresePoMusterijiAsync(musterijaId);
            var adreseDto = _mapper.Map<List<AdresaDto>>(adrese);

            return Ok(adreseDto);
        }
    }

}
