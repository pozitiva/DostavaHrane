namespace DostavaHrane.Entiteti

{
    public class Restoran: Korisnik
    {
        public string? Opis{ get; set; }
        public string SlikaUrl { get; set; }
        //ocena restorana, adresa
        public ICollection<Jelo> Jela { get; set; }
        public ICollection<Narudzbina> Narudzbine { get; set; }
    }
}
    