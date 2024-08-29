using DostavaHrane.Entiteti;
using System.ComponentModel.DataAnnotations;

namespace DostavaHrane.Dto
{
    public class JeloDto
    {
        [Required]
        public string Naziv { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Cena { get; set; }
        [Required]
        public string TipJela { get; set; }
        [Required]
        public int RestoranId { get; set; }
        public int Id { get; set; }

    }
}
