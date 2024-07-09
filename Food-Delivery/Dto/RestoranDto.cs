using DostavaHrane.Entiteti;

namespace DostavaHrane.Dto
{
    public class RestoranDto
    {
        public string Ime{ get; set;}
        public string RadnoVreme { get; set; }

        public Dostavljac Dostavljac { get; set; }
        public Restoran Restoran { get; set; }
        public Adresa Adresa { get; set; }
    }
}
