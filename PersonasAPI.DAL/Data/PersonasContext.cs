using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PersonasAPI.DAL.Models;

namespace PersonasAPI.DAL.Data
{
    public partial class PersonasContext : DbContext
    {
        public PersonasContext()
        {
        }

        public PersonasContext(DbContextOptions<PersonasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Documento> Documentos { get; set; } = null!;
        public virtual DbSet<Genero> Generos { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-N3U9N54;Initial Catalog=Personas;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Documento>(entity =>
            {
                entity.ToTable("Documento");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Abreviatura).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.ToTable("Genero");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.GeneroName)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persona");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(100)
                    .IsFixedLength();

                //entity.HasOne(d => d.IdDocumentoNavigation)
                //    .WithMany(p => p.Personas)
                //    .HasForeignKey(d => d.IdDocumento)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_IdDocumento");

                //entity.HasOne(d => d.IdGeneroNavigation)
                //    .WithMany(p => p.Personas)
                //    .HasForeignKey(d => d.IdGenero)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_IdGenero");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
