using System.ComponentModel.DataAnnotations;

namespace Food_Delivery.Entiteti
{
    public class LoginZahtev
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Sifra { get; set; } = string.Empty;
    }
}
