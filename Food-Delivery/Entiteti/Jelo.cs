﻿namespace DostavaHrane.Entiteti
{
    public class Jelo
    {
        public int Id { get; set; }
        public string Naziv {  get; set; }
        public decimal Cena { get; set; }
        public string TipJela { get; set; }


        public Restoran? Restoran { get; set; }
        public int RestoranId { get; set; }

        public ICollection<StavkaNarudzbine>? StavkeNarudzbine { get; set; }
     }
}
