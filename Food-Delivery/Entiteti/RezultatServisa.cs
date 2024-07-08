namespace Food_Delivery.Entiteti
{
    public class RezultatServisa<T>
    {
            public T Objekat { get; set; }
            public bool Uspesno { get; set; }
            public string PorukaGreske { get; set; }
            public int StatusniKod { get; set; }
       
    }
}
