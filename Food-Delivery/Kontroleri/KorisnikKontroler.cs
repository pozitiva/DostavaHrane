using AutoMapper;
using DostavaHrane.Dto;
using DostavaHrane.Servisi;
using DostavaHrane.Servisi.Interfejsi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DostavaHrane.Kontroleri
{

    [Route("api/korisnik")]
    [ApiController]
    public class KorisnikKontroler:ControllerBase
    {
        private readonly IRestoranServis _restoranServis;
        private readonly IMusterijaServis _musterijaServis;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public KorisnikKontroler(IMusterijaServis musterijaServis, IRestoranServis restoranServis, IMapper mapper, IConfiguration configuration)
        {
            _musterijaServis = musterijaServis;
            _restoranServis = restoranServis;
            _mapper = mapper;
            _configuration = configuration;

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

            var token = GenerateJwtToken(rezultat.Id.ToString());
            return Ok( new { rezultat, token});
        }


        [HttpPost("restoran/login")]
        public async Task<IActionResult> RestoranLogin(KorisnikLoginDto restoranDto)
        {
            var rezultat = await _restoranServis.UlogujRestoranAsync(restoranDto);

            if (rezultat == null)
            {
                return BadRequest("Neuspesno logovanje");
            }

            var token = GenerateJwtToken(rezultat.Id.ToString());
            return Ok(new { rezultat, token });
        }

        private string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
