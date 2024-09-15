using AutoMapper;
using DostavaHrane.AplikacioniSloj.Interfejsi;
using DostavaHrane.Dto;
using DostavaHrane.Entiteti;
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
 
        private readonly IAuthServis _authServis;
        private readonly IConfiguration _configuration;

        public KorisnikKontroler(IAuthServis authServis, IConfiguration configuration)
        {
            _authServis = authServis;
            _configuration = configuration;

        }

        [HttpPost("musterija/register")]
        public async Task<IActionResult> MusterijaRegistracija(MusterijaRegistracijaDto musterijaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string rezultat = await _authServis.RegistrujMusterijuAsync(musterijaDto);

            if (rezultat == "Nalog sa ovim emailom vec postoji!" || rezultat == "Unete sifre se ne podudaraju")
            {
                return BadRequest(rezultat);
            }

            return Ok("Musterija je uspesno registrovana");
        }


        [HttpPost("musterija/login")]
        public async Task<IActionResult> MusterijaLogin(KorisnikLoginDto musterijaDto)
        {
            
            var rezultat = await _authServis.UlogujMusterijuAsync(musterijaDto);

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
            var rezultat = await _authServis.UlogujRestoranAsync(restoranDto);

            if (rezultat == null)
            {
                return BadRequest("Neuspesno logovanje");
            }

            var token = GenerateJwtToken(rezultat.Id.ToString());
            return Ok(new { rezultat, token });
        }

        [HttpPost("admin/login")]
        public async Task<IActionResult> AdminLogin(KorisnikLoginDto adminDto)
        {
            var rezultat = await _authServis.UlogujAdminaAsync(adminDto);

            if (rezultat == null)
            {
                return BadRequest("Neuspesno logovanje");
            }

            //var token = GenerateJwtToken(rezultat.Id.ToString());
            return Ok( rezultat);
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
