namespace DostavaHrane.Entiteti
{
    public class AdresaMusterije
    {
        public int MusterijaId { get; set; }
        public int AdresaId { get; set; }
        public Musterija Musterija { get; set; }
        public Adresa Adresa { get; set; }
    }
}
