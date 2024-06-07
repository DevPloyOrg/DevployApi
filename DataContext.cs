using DevPloyClasses.Models;
using Microsoft.EntityFrameworkCore;

namespace DevPloyApiApi
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<AdvancedForm> AdvancedForms { get; set; }
        public DbSet<BaseFormModel> BaseForms { get; set; }
    }
}
