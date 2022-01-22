using Core_MVC_CRUD.Infrastructure.EntityTypeConfiguration.Concrete;
using Core_MVC_CRUD.Models.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Core_MVC_CRUD.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // .Net gibi buraya Connection String ifademizi yazmıyoruz. Core da yapmayacağız.
            // Core da appsettings.json dosyasını kullanacağız
        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
