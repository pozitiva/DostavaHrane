using DostavaHrane.Entiteti;

namespace DostavaHrane.Dto
{
    public class RestoranDto
    {
        public string Ime{ get; set;}
        public string Opis { get; set; }

        public int Id { get; set; }
        public string SlikaUrl { get; set; }
        public ICollection<JeloDto> Jela { get; set; }

    }
}
