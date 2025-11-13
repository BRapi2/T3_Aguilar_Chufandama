using Microsoft.EntityFrameworkCore;
using T3_Aguilar_Chufandama.Models;

namespace T3_Aguilar_Chufandama.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; } = null!;
    }
}