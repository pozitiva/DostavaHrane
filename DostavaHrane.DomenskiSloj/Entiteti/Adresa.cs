using System.Text.Json.Serialization;

namespace DostavaHrane.Entiteti

{
    public class Adresa
    {
        public int Id { get; set; }
        public string Naziv {  get; set; }
        public string Ulica { get; set; }
        public string Grad {  get; set; }

        [JsonIgnore]
        public Musterija? Musterija { get; set; }
        public int MusterijaId { get; set; }

        public ICollection<Narudzbina> Narudzbine { get; set; }

    }
}
