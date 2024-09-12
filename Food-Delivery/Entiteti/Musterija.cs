namespace DostavaHrane.Entiteti

{
    public class Musterija:Korisnik
    {
        public string BrojTelefona { get; set; }
        public ICollection<Adresa> Adrese { get; set; }
        public ICollection<Narudzbina> Narudzbine { get; set; }
    }
}
