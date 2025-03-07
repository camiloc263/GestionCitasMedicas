namespace CitasMedicas.Infrastructure.Repository
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CitaMedicaContext : DbContext
    {
        public CitaMedicaContext()
            : base("name=Citas")
        {
        }

        public virtual DbSet<CitaMedica> citamedica { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CitaMedica>()
                .ToTable("CitaMedica");

            modelBuilder.Entity<CitaMedica>()
                .Property(e => e.lugarcita)
                .IsUnicode(false);

            modelBuilder.Entity<CitaMedica>()
                .Property(e => e.estadocita)
                .IsUnicode(false);
        }
    }
}
