using Microsoft.EntityFrameworkCore;
using CoffeeBookApi.Models;

namespace CoffeeBookApi.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<CoffeeBooking> Booking { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options):
            base(options)
        {

        }
    }
}
