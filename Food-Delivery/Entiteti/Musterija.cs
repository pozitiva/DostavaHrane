namespace DostavaHrane.Entiteti

{
    public class Musterija:Korisnik
    {
        public string Email { get; set; }
        public byte[] SifraHash { get; set; } = new byte[32];
        public byte[] SifraSalt { get; set ;} = new byte[32];
        public string? VerifikacioniToken { get; set; }

        public ICollection<AdresaMusterije> AdreseMusterija { get; set; }
    }
}
