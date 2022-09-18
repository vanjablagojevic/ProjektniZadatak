using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjektniZadatak.Models
{
    public partial class ZadatakContext : DbContext
    {
        public ZadatakContext()
        {
        }

        public ZadatakContext(DbContextOptions<ZadatakContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artikal> Artikals { get; set; } = null!;
        public virtual DbSet<Atributiartikla> Atributiartiklas { get; set; } = null!;
        public virtual DbSet<Jedinicamjere> Jedinicamjeres { get; set; } = null!;
        public virtual DbSet<Vrsteatributum> Vrsteatributa { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Zadatak;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artikal>(entity =>
            {
                entity.ToTable("ARTIKAL");

                entity.HasIndex(e => e.Jedinicamjereid, "JEDINICAMJEREARTIKLA_FK");

                entity.Property(e => e.Artikalid).HasColumnName("ARTIKALID");

                entity.Property(e => e.Artikalnaziv)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ARTIKALNAZIV");

                entity.Property(e => e.Artikalsifra)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ARTIKALSIFRA");

                entity.Property(e => e.Jedinicamjereid).HasColumnName("JEDINICAMJEREID");

                entity.HasOne(d => d.Jedinicamjere)
                    .WithMany(p => p.Artikals)
                    .HasForeignKey(d => d.Jedinicamjereid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ARTIKAL_JEDINICAM_JEDINICA");
            });

            modelBuilder.Entity<Atributiartikla>(entity =>
            {
                entity.HasKey(e => new { e.Artikalid, e.Vrstaatributaid });

                entity.ToTable("ATRIBUTIARTIKLA");

                entity.HasIndex(e => e.Vrstaatributaid, "ATRIBUTIARTIKLA2_FK");

                entity.HasIndex(e => e.Artikalid, "ATRIBUTIARTIKLA_FK");

                entity.Property(e => e.Artikalid).HasColumnName("ARTIKALID");

                entity.Property(e => e.Vrstaatributaid).HasColumnName("VRSTAATRIBUTAID");

                entity.Property(e => e.Vrijednostatributa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VRIJEDNOSTATRIBUTA");

                entity.HasOne(d => d.Artikal)
                    .WithMany(p => p.Atributiartiklas)
                    .HasForeignKey(d => d.Artikalid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ATRIBUTI_ATRIBUTIA_ARTIKAL");

                entity.HasOne(d => d.Vrstaatributa)
                    .WithMany(p => p.Atributiartiklas)
                    .HasForeignKey(d => d.Vrstaatributaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ATRIBUTI_ATRIBUTIA_VRSTEATR");
            });

            modelBuilder.Entity<Jedinicamjere>(entity =>
            {
                entity.ToTable("JEDINICAMJERE");

                entity.Property(e => e.Jedinicamjereid).HasColumnName("JEDINICAMJEREID");

                entity.Property(e => e.Jedinicamjerenaziv)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("JEDINICAMJERENAZIV");

                entity.Property(e => e.Jedinicamjereskracenica)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("JEDINICAMJERESKRACENICA");
            });

            modelBuilder.Entity<Vrsteatributum>(entity =>
            {
                entity.HasKey(e => e.Vrstaatributaid);

                entity.ToTable("VRSTEATRIBUTA");

                entity.Property(e => e.Vrstaatributaid).HasColumnName("VRSTAATRIBUTAID");

                entity.Property(e => e.Vrstaatributanaziv)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VRSTAATRIBUTANAZIV");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
