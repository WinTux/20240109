using Microsoft.EntityFrameworkCore;
using Principal.Models;

namespace Principal.Repos
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Plato> platos { get; set; }
        public RestaurantDbContext( DbContextOptions<RestaurantDbContext> options) : base(options)
        {
            
        }
    }
}
