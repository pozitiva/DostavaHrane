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

            modelBuilder.Entity<StavkaNarudzbine>()
            .HasKey(sn => new { sn.JeloId, sn.NarudzbinaId });

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
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.Adresa)
                .WithMany(u => u.Narudzbine)
                .HasForeignKey(s => s.AdresaId)
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

            // One-to-Many: Narudzbina -> StavkeNarudzbine
            //modelBuilder.Entity<StavkaNarudzbine>()
            //    .HasOne(sn => sn.Narudzbina)
            //    .WithMany(n => n.StavkeNarudzbine)
            //    .HasForeignKey(sn => sn.NarudzbinaId);

            // One-to-Many: Jelo -> StavkeNarudzbine
            //modelBuilder.Entity<StavkaNarudzbine>()
            //    .HasOne(sn => sn.Jelo)
            //    .WithMany(j => j.StavkeNarudzbine)
            //    .HasForeignKey(sn => sn.JeloId);

            // Many-to-One: Narudzbina -> Dostavljac
            //modelBuilder.Entity<Narudzbina>()
            //    .HasOne(n => n.Dostavljac)
            //    .WithMany(d => d.Narudzbine)
            //    .HasForeignKey(n => n.DostavljacId)
            //    .OnDelete(DeleteBehavior.Restrict); // Optional: Prevent cascade delete

            // Many-to-One: Narudzbina -> Restoran
            //modelBuilder.Entity<Narudzbina>()
            //    .HasOne(n => n.Restoran)
            //    .WithMany(r => r.Narudzbine)
            //    .HasForeignKey(n => n.RestoranId)
            //    .OnDelete(DeleteBehavior.Restrict); 

            // Many-to-One: Narudzbina -> Adresa
            //modelBuilder.Entity<Narudzbina>()
            //    .HasOne(n => n.Adresa)
            //    .WithMany(a => a.Narudzbine)
            //    .HasForeignKey(n => n.AdresaId)
             //   .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

    }



}

