using Microsoft.AspNetCore.Identity;

namespace DostavaHrane.Entiteti

{
    public class Korisnik:IdentityUser
    {

        public string? Ime {  get; set; }


    }
}
