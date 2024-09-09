using DostavaHrane.Data;
using DostavaHrane.Repozitorijum.Interfejsi;
using Microsoft.EntityFrameworkCore.Storage;

namespace DostavaHrane.Repozitorijum
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly Lazy<IAdresaRepozitorijum> _adresaRepozitorijum;
        private readonly Lazy<IDostavljacRepozitorijum> _dostavljacRepozitorijum;
        private readonly Lazy<IJeloRepozitorijum> _jeloRepozitorijum;
        private readonly Lazy<IMusterijaRepozitorijum> _musterijaRepozitorijum;
        private readonly Lazy<INarudzbinaRepozitorijum> _narudzbinaRepozitorijum;
        private readonly Lazy<IRestoranRepozitorijum> _restoranRepozitorijum;
        private readonly Lazy<IAdminRepozitorijum > _adminRepozitorijum;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            _adresaRepozitorijum = new Lazy<IAdresaRepozitorijum>(() => new AdresaRepozitorijum(_context));
            _dostavljacRepozitorijum = new Lazy<IDostavljacRepozitorijum>(() => new DostavljacRepozitorijum(_context));
            _jeloRepozitorijum = new Lazy<IJeloRepozitorijum>(() => new JeloRepozitorijum(_context));
            _musterijaRepozitorijum = new Lazy<IMusterijaRepozitorijum>(() => new MusterijaRepozitorijum(_context));
            _narudzbinaRepozitorijum = new Lazy<INarudzbinaRepozitorijum>(()=> new NarudzbinaRepozitorijum(_context));
            _restoranRepozitorijum = new Lazy<IRestoranRepozitorijum>(() => new RestoranRepozitorijum(_context));
            _adminRepozitorijum = new Lazy<IAdminRepozitorijum>(() => new AdminRepozitorijum(_context));
        }
        public IAdresaRepozitorijum AdresaRepozitorijum => _adresaRepozitorijum.Value;

        public IDostavljacRepozitorijum DostavljacRepozitorijum => _dostavljacRepozitorijum.Value;

        public IJeloRepozitorijum JeloRepozitorijum => _jeloRepozitorijum.Value;

        public IMusterijaRepozitorijum MusterijaRepozitorijum => _musterijaRepozitorijum.Value;

        public INarudzbinaRepozitorijum NarudzbinaRepozitorijum => _narudzbinaRepozitorijum.Value;

        public IRestoranRepozitorijum RestoranRepozitorijum => _restoranRepozitorijum.Value;

        public IAdminRepozitorijum AdminRepozitorijum => _adminRepozitorijum.Value;

        public async Task SaveChanges() => await _context.SaveChangesAsync();


    }
}
