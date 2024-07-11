using DostavaHrane.Entiteti;

namespace DostavaHrane.Dto
{
    public class NarudzbinaDto
    {
        public decimal UkupnaCena { get; set; }
        public int RestoranId { get; set; }
        public int AdresaId { get; set; }

        public int MusterijaId {get; set; }
    }
}
