using dotnet_core_rpg.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_core_rpg.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}