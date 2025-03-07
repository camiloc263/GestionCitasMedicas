using RecetasMedicas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecetasMedicas.Infrastructure.Repository
{
    public class FormulaMedicaContext : DbContext
    {
        public FormulaMedicaContext()
        : base("name=RecetaMedica")
        {
        }

        public virtual DbSet<FormulaMedica> RecetaMedica{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormulaMedica>()
                .ToTable("RecetasMedicas");

            modelBuilder.Entity<FormulaMedica>()
                .Property(e => e.CodigoReceta)
                .IsUnicode(false);

            modelBuilder.Entity<FormulaMedica>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<FormulaMedica>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

        }
    }}