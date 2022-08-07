using CarProject.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarProject.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<BoatEntity> Boats { get; set; }
        public DbSet<BusEntity> Busses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
