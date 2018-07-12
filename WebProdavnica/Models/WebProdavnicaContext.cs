using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebProdavnica.Models;

namespace WebProdavnica.Models
{
    public partial class WebProdavnicaContext : DbContext
    {
        public WebProdavnicaContext()
        {
        }

        public WebProdavnicaContext(DbContextOptions<WebProdavnicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kategorija> Kategorije { get; set; }
        public virtual DbSet<Porudzbina> Porudzbine { get; set; }
        public virtual DbSet<Proizvod> Proizvodi { get; set; }
        public virtual DbSet<Stavka> Stavke { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Porudzbina>(entity =>
            {
                entity.Property(e => e.DatumKupovine).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Proizvod>(entity =>
            {
                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.Proizvodi)
                    .HasForeignKey(d => d.KategorijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proizvod__Katego__619B8048");
            });

            modelBuilder.Entity<Stavka>(entity =>
            {
                entity.HasOne(d => d.Porudzbina)
                    .WithMany(p => p.Stavke)
                    .HasForeignKey(d => d.PorudzbinaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stavka__Porudzbi__6477ECF3");

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.Stavke)
                    .HasForeignKey(d => d.ProizvodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stavka__Proizvod__656C112C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
