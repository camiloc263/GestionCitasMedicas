namespace Persona.Infrastructure.Repository
{

    using System.Data.Entity;
    using Persona.Application.DTO;
    using Persona.Domain.Entities;

    public partial class PersonaContext : DbContext
    {
        public PersonaContext()
            : base("Persona")
        {
        }

        public virtual DbSet<ListaPersona> ListaPersona { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListaPersona>()
                .ToTable("ListaPersona");

            modelBuilder.Entity<ListaPersona>()
                .Property(e => e.tipoDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<ListaPersona>()
                .Property(e => e.numeroDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<ListaPersona>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<ListaPersona>()
                .Property(e => e.apellidoUno)
                .IsUnicode(false);

            modelBuilder.Entity<ListaPersona>()
                .Property(e => e.apellidoDos)
                .IsUnicode(false);

            modelBuilder.Entity<ListaPersona>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<ListaPersona>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<ListaPersona>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<ListaPersona>()
                .Property(e => e.tipoUsuario)
                .IsUnicode(false);
        }
    }
}
