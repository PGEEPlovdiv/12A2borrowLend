using Microsoft.EntityFrameworkCore;
using PyrvoZadanie.Models;

namespace PyrvoZadanie.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        
        public DbSet<Item> Items { get; set; }
    }
}
