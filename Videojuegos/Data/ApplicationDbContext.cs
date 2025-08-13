using Microsoft.EntityFrameworkCore;
using Videojuegos.Models;
using System.Collections.Generic;

namespace Videojuegos.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Videojuego> Videojuegos { get; set; }
    }
}
