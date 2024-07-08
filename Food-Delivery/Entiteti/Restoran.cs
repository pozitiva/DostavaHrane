namespace DostavaHrane.Entiteti

{
    public class Restoran: Korisnik
    {
        public string? RadnoVreme { get; set; }
        //ocena restorana, adresa
        public ICollection<Jelo> Jela { get; set; }
    }
}
    