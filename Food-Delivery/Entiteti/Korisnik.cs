namespace DostavaHrane.Entiteti

{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime {  get; set; }

        public string Email { get; set; }
        public string TipKorisnika  { get; set; }
        public byte[] SifraHash { get; set; } = new byte[32];
        public byte[] SifraSalt { get; set; } = new byte[32];

    }
}
