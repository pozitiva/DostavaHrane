﻿using System.ComponentModel.DataAnnotations;

namespace DostavaHrane.Dto
{
    public class KorisnikLoginDto
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Sifra { get; set; } = string.Empty;

        public string TipKorisnika { get; set; } = string.Empty;
    }
}
