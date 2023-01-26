using EPP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZerEquiposApp.Models;

namespace ZerEquiposApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        //Entidad Equipo
        public DbSet<Procesador> Procesador { get; set; }
        public DbSet<Memorias> Memoria { get; set; }
        public DbSet<Equipo> Equipo { get; set; }
        public DbSet<Licenciamiento> Licenciamiento { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<SO> SO { get; set; }
        public DbSet<Canon> Canon { get; set; }
        //Entidad Empleado
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Cargo> Cargo { get; set; }

    }
}