
using Microsoft.EntityFrameworkCore.Storage;

namespace DostavaHrane.Repozitorijum.Interfejsi
{
    public interface IUnitOfWork
    {
        IAdresaRepozitorijum AdresaRepozitorijum { get; }
        IDostavljacRepozitorijum DostavljacRepozitorijum { get; }
        IJeloRepozitorijum JeloRepozitorijum { get; }
        IMusterijaRepozitorijum MusterijaRepozitorijum { get; }
        INarudzbinaRepozitorijum NarudzbinaRepozitorijum { get; }
        IRestoranRepozitorijum RestoranRepozitorijum { get; }
        IAdminRepozitorijum AdminRepozitorijum { get; }
        Task SaveChanges();
       
    }
}
