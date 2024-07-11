namespace DostavaHrane.Entiteti

{
    public class Musterija:Korisnik
    {
        public string Email { get; set; }
        public byte[] SifraHash { get; set; } = new byte[32];
        public byte[] SifraSalt { get; set ;} = new byte[32];
        public string? VerifikacioniToken { get; set; }

        public ICollection<Adresa> Adrese { get; set; }
        public ICollection<Narudzbina> Narudzbine { get; set; }
    }
}
