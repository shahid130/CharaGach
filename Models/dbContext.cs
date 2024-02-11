using Microsoft.EntityFrameworkCore;
using CharaGach.Models;

namespace CharaGach.Models
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Users> userInfo { get; set; }
        public DbSet<Admins> adminInfo { get; set; }
        public DbSet<Plants> plants { get; set; } 
        public DbSet<CartModel> cart{ get; set; }
        public DbSet<Order> orders { get; set; }
    }
}
