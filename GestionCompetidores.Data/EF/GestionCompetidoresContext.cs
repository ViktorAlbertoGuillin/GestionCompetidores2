using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GestionCompetidores.Data.EF
{
    public partial class GestionCompetidoresContext : DbContext
    {
        public GestionCompetidoresContext()
        {
        }

        public GestionCompetidoresContext(DbContextOptions<GestionCompetidoresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Competidor> Competidors { get; set; } = null!;
        public virtual DbSet<Deporte> Deportes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-BUTNA10\\SQLEXPRESS;Database=GestionCompetidores;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competidor>(entity =>
            {
                entity.HasKey(e => e.IdCompetidor)
                    .HasName("PK__Competid__1B4C0B7674A58977");

                entity.ToTable("Competidor");

                entity.Property(e => e.NombreCompetidor).HasMaxLength(50);

                entity.HasOne(d => d.IdDeporteNavigation)
                    .WithMany(p => p.Competidors)
                    .HasForeignKey(d => d.IdDeporte)
                    .HasConstraintName("fk_IdDeporte");
            });

            modelBuilder.Entity<Deporte>(entity =>
            {
                entity.HasKey(e => e.IdDeporte)
                    .HasName("PK__Deporte__B5FFCC7D75D8560F");

                entity.ToTable("Deporte");

                entity.Property(e => e.NombreDeporte).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
