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
                entity.HasKey(sn => new { sn.JeloId, sn.NarudzbinaId });

                //entity.HasOne(p => p.Narudzbina)
                //    .WithMany(pc => pc.StavkeNarudzbine)
                //    .HasForeignKey(p => p.NarudzbinaId);

                //entity.HasOne(p => p.Jelo)
                //    .WithMany(pc => pc.StavkeNarudzbine)
                //    .HasForeignKey(p => p.JeloId);
            });

            modelBuilder.Entity<Narudzbina>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(s => s.Restoran)
                    .WithMany(u => u.Narudzbine)
                    .HasForeignKey(s => s.RestoranId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.Dostavljac)
                    .WithMany(u => u.Narudzbine)
                    .HasForeignKey(s => s.DostavljacId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.Adresa)
                    .WithMany(u => u.Narudzbine)
                    .HasForeignKey(s => s.AdresaId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.Musterija)
                    .WithMany(u => u.Narudzbine)
                    .HasForeignKey(s => s.MusterijaId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.StavkeNarudzbine)
                    .WithOne(e => e.Narudzbina)
                    .HasForeignKey(e => e.NarudzbinaId);
            });

            modelBuilder.Entity <Adresa>(entity =>
            {
                entity.HasOne(s => s.Musterija)
                    .WithMany(u => u.Adrese)
                    .HasForeignKey(s => s.MusterijaId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }

    }



}

