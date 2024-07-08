using Microsoft.AspNetCore.Mvc;
using DostavaHrane.Servisi.Interfejsi;
using DostavaHrane.Entiteti;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using DostavaHrane.Data;
using System.Security.Cryptography;
using System.Text;
using Food_Delivery.Entiteti;
using Food_Delivery.Servisi;

namespace DostavaHrane.Kontroleri
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusterijaKontroler : ControllerBase 
    {
 
        private readonly IMusterijaServis _musterijaServis;
        public MusterijaKontroler(IMusterijaServis musterijaServis)
        {
            _musterijaServis = musterijaServis;

        }


        [HttpPost("register")]
        public async Task<IActionResult> Registracija(RegistracijaZahtev zahtev)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            string rezultat = await _musterijaServis.RegistrujMusterijuAsync(zahtev);
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
        public async Task<IActionResult> Login(LoginZahtev zahtev)
        {
            if (string.IsNullOrEmpty(zahtev.Email) || string.IsNullOrEmpty(zahtev.Sifra))
            {
                return BadRequest(new { message = "Email i sifra su obavezna polja!" });
            }

            var rezultat = await _musterijaServis.UlogujMusterijuAsync(zahtev);

            if (!rezultat.Uspesno)
            {
                switch (rezultat.StatusniKod)
                {
                    case 401:
                        return Unauthorized(new { message = rezultat.PorukaGreske });
                    case 404:
                        return NotFound(new { message = rezultat.PorukaGreske });
                    default:
                        return StatusCode(rezultat.StatusniKod, new { message = rezultat.PorukaGreske });
                }
            }

            return Ok(new { message = "Uspesno ste ulogovani", user = rezultat.Objekat });

        }
    }

}
