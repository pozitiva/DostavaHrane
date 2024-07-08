namespace DostavaHrane.Repozitorijum.Interfejsi
{
    public interface IRepozitorijum<T> where T : class
    {
        Task<IEnumerable<T>> VratiSveAsync();
        Task<T> VratiPoIdAsync(int id);
        Task DodajAsync(T entity);
        Task IzmeniAsync(T entity);
        Task ObrisiAsync(T entity);
    }
}
