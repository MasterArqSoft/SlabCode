using CodeFirst.Domain.Entities;
using CodeFirst.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CodeFirst.Infrastructure.Settings
{
    public class CodeFirstContext : DbContext
    {
        public CodeFirstContext()
        {
        }

        public CodeFirstContext(DbContextOptions<CodeFirstContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=DESKTOP-D7A5IA9; User ID=sa; password=Santi79/*; database=slabcode; Integrated Security = true;");
            }
        }
        public virtual DbSet<EstadoProyecto> EstadoProyectos { get; set; }
        public virtual DbSet<EstadoTarea> EstadoTareas { get; set; }
        public virtual DbSet<Proyecto> Proyectos { get; set; }
        public virtual DbSet<Tarea> Tareas { get; set; }
        public virtual DbSet<Seguridad> Seguridad { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.SeedData();
            base.OnModelCreating(modelBuilder);
        }
    }
}