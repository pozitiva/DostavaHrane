using Microsoft.AspNetCore.Mvc;
using DostavaHrane.Servisi.Interfejsi;
using DostavaHrane.Entiteti;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using DostavaHrane.Data;
using System.Security.Cryptography;
using System.Text;
using DostavaHrane.Entiteti;
using DostavaHrane.Servisi;

namespace DostavaHrane.Kontroleri
{
    [Route("api/musterija")]
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


            var rezultat = await _musterijaServis.UlogujMusterijuAsync(zahtev);

            if(rezultat== null)
            {
                return BadRequest("Neuspesno logovanje");
            }
           

            return Ok("Korisnik je uspesno ulogovan");

        }
    }

}
