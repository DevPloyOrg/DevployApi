using DevPloyClasses.Models;
using DevPloyClasses.Models;
using Microsoft.EntityFrameworkCore;

namespace AgentBuilderApi
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<AdvancedForm> AdvancedForms { get; set; }
        public DbSet<BaseFormModel> BaseForms { get; set; }
    }
}
