using ADSProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<EstudianteViewModel> Estudiantes { get; set; } 

        public DbSet<MateriaViewModel> Materias { get; set; }

        public DbSet<ProfesoresViewModel> Profesores { get; set; }

        public DbSet<CarreraViewModel> Carreras { get; set; }

        public DbSet<GruposViewModel>  Grupos { get; set; }

    }
}
