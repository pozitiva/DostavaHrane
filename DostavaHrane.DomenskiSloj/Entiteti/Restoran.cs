using System.Text.Json.Serialization;

namespace DostavaHrane.Entiteti

{
    public class Restoran: Korisnik
    {
        public string? Opis{ get; set; }
        public string SlikaUrl { get; set; }
        //ocena restorana, adresa
        public ICollection<Jelo> Jela { get; set; }
        [JsonIgnore]
        public ICollection<Narudzbina> Narudzbine { get; set; }
    }
}
    