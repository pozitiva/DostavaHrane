namespace DostavaHrane.Entiteti

{
    public class StavkaNarudzbine
    {
        public int Kolicina { get; set; }

        public int JeloId { get; set; }
        public int NarudzbinaId { get; set; }
        public Jelo Jelo { get; set; }
        public Narudzbina Narudzbina { get; set; }
    }
}
