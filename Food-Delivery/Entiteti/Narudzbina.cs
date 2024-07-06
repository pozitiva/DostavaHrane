namespace DostavaHrane.Entiteti

{
    public class Narudzbina
    {
        public int Id { get; set; }
        public DateTime DatumNarudzbine { get; set; }
        public string Status { get; set; } // na cekanju; u pripremi; dostavljeno...
        public decimal UkupnaCena { get; set; }

        public Dostavljac Dostavljac { get; set; }
        public Restoran Restoran { get; set; } 
        public Adresa Adresa { get; set; }

        public ICollection<StavkaNarudzbine> StavkeNarudzbine { get; set; }

    }
}
