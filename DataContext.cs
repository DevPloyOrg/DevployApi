using AgentBuilderClasses.Models;
using Microsoft.EntityFrameworkCore;

namespace AgentBuilderApi
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
    }
}
