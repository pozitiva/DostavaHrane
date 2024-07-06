namespace DostavaHrane.Entiteti

{
    public class Musterija:Korisnik
    {
        public string Email { get; set; }
        public ICollection<AdresaMusterije> AdreseMusterija { get; set; }
    }
}
