using DostavaHrane.Entiteti;
using Microsoft.EntityFrameworkCore;

namespace DostavaHrane.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }

        public DbSet<Adresa> Adrese { get; set; }
        public DbSet<AdresaMusterije> AdreseMusterija { get; set; }
        public DbSet<Dostavljac> Dostavljaci { get; set; }
        public DbSet<Jelo> Jela { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Musterija> Musterije { get; set; }
        public DbSet<Narudzbina> Narudzbine { get; set; }
        public DbSet<Restoran> Restorani { get; set; }
        public DbSet<StavkaNarudzbine> StavkeNarudzbina { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Korisnik>()
                .ToTable("Korisnici");

            modelBuilder.Entity<Musterija>()
                .ToTable("Musterije")
                .HasBaseType<Korisnik>();

            modelBuilder.Entity<Restoran>()
                .ToTable("Restorani")
                .HasBaseType<Korisnik>();

            modelBuilder.Entity<AdresaMusterije>()
                .HasKey(am => new { am.MusterijaId, am.AdresaId });

            modelBuilder.Entity<AdresaMusterije>()
                .HasOne(m => m.Musterija)
                .WithMany(am => am.AdreseMusterija)
                .HasForeignKey(m => m.MusterijaId);

            modelBuilder.Entity<AdresaMusterije>()
                .HasOne(a => a.Adresa)
                .WithMany(am => am.AdreseMusterija)
                .HasForeignKey(a => a.AdresaId);

            modelBuilder.Entity<Narudzbina>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DatumNarudzbine).IsRequired();
                entity.Property(e => e.Status).HasMaxLength(50).IsRequired();
                entity.Property(e => e.UkupnaCena).HasColumnType("decimal(18,2)");

                entity.HasOne(e => e.Dostavljac)
                    .WithMany()
                    .HasForeignKey("DostavljacId")
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Restoran)
                    .WithMany()
                    .HasForeignKey("RestoranId")
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Adresa)
                    .WithMany()
                    .HasForeignKey("AdresaId")
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.StavkeNarudzbine)
                    .WithOne(e => e.Narudzbina)
                    .HasForeignKey(e => e.NarudzbinaId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Jelo entity
            modelBuilder.Entity<Jelo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Naziv).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Cena).HasColumnType("decimal(18,2)");
                entity.Property(e => e.TipJela).HasMaxLength(50).IsRequired();

                entity.HasMany(e => e.StavkeNarudzbine)
                    .WithOne(e => e.Jelo)
                    .HasForeignKey(e => e.JeloId);

                entity.HasOne(s => s.Restoran)
                .WithMany(u => u.Jela)
                .HasForeignKey(s => s.RestoranId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<StavkaNarudzbine>(entity =>
            {
                entity.HasKey(e => new { e.JeloId, e.NarudzbinaId });

                entity.HasOne(e => e.Jelo)
                    .WithMany(j => j.StavkeNarudzbine)
                    .HasForeignKey(e => e.JeloId);

                entity.HasOne(e => e.Narudzbina)
                    .WithMany(n => n.StavkeNarudzbine)
                    .HasForeignKey(e => e.NarudzbinaId);
            });

            // Configure StavkaNarudzbine entity
            modelBuilder.Entity<StavkaNarudzbine>(entity =>
            {
                entity.HasKey(e => new {  e.JeloId, e.NarudzbinaId });

                entity.Property(e => e.Kolicina).IsRequired();

                entity.HasOne(e => e.Jelo)
                    .WithMany(e => e.StavkeNarudzbine)
                    .HasForeignKey(e => e.JeloId);
                //.OnDelete(DeleteBehavior.Restrict);


                entity.HasOne(e => e.Narudzbina)
                    .WithMany(e => e.StavkeNarudzbine)
                    .HasForeignKey(e => e.NarudzbinaId);
                    //.OnDelete(DeleteBehavior.Restrict);

            });

            base.OnModelCreating(modelBuilder);
        }

    }



}

