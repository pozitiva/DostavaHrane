using DostavaHrane.Entiteti;

namespace DostavaHrane.Dto
{
    public class NarudzbinaDto
    {
        public int Id { get; set; }
        public int RestoranId { get; set; }
        public DateTime DatumNarudzbine { get; set; }
        public string? Status { get; set; }

        public decimal? UkupnaCena { get; set; }
        public int? DostavljacId { get; set; }

        public int? AdresaId { get; set; }
        public int? MusterijaId { get; set; }

        public string? Adresa { get; set; }
        public string? MusterijaIme { get; set; }
        public string? DostavljacIme { get; set; }

        public ICollection<StavkaNarudzbineDto> StavkeNarudzbine { get; set; }


        }
    }
