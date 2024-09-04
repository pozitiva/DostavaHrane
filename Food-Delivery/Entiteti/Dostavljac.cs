namespace DostavaHrane.Entiteti
{
    public class Dostavljac
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string BrojTelefona { get; set; }
        public int BrojDostava { get; set; } = 0;

        public bool Slobodan { get; set; } = true;
        public ICollection<Narudzbina> Narudzbine { get; set; }
    }
}
