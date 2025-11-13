using Microsoft.EntityFrameworkCore;
using T3_Apellido_Nombre.Models;

namespace T3_Apellido_Nombre.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; } = null!;
    }
}