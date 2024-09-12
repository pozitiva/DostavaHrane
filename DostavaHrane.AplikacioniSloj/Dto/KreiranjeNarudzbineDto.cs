namespace DostavaHrane.Dto
{
    public class KreiranjeNarudzbineDto
    {
        public int RestoranId { get; set; }
        public int AdresaId { get; set; }
        public List<StavkaNarudzbineDto> StavkeNarudzbine { get; set; }
    }
}
