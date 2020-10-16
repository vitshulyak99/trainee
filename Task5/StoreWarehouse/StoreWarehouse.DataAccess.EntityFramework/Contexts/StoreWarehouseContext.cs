using Microsoft.EntityFrameworkCore;
using StoreWarehouse.DataAccess.EntityFramework.Models;

namespace StoreWarehouse.DataAccess.EntityFramework.Contexts
{
    public class StoreWarehouseContext : DbContext
    {
        private string _connectionString;

        public StoreWarehouseContext()
        {
            Database.EnsureCreated();
        }

        public StoreWarehouseContext(string connectionString) : base()
        {
            _connectionString = connectionString;
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<SubCategoryGood> SubCategoryGoods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // ConfigurationBuilder builder = new ConfigurationBuilder();
            // builder.AddJsonFile(@"appsettings.json");

            // base.OnConfiguring(optionsBuilder.UseSqlServer(builder.Build().GetConnectionString("CategoriesDB")));
            //base.OnConfiguring(optionsBuilder.UseSqlServer(builder.Build().GetConnectionString("EFDatabase")));
            //base.OnConfiguring(optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=db/EFTest.StoreWarehouse.db;Trusted_Connection=True;"));
            base.OnConfiguring(optionsBuilder.UseSqlServer(_connectionString));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>()
                    .HasMany(s => s.SubCategories)
                    .WithOne(s => s.Category);

            modelBuilder.Entity<Category>()
                    .HasKey(k => k.Id);

            modelBuilder.Entity<SubCategoryGood>()
                    .HasKey(s => new { s.Id });

            modelBuilder.Entity<SubCategoryGood>()
                    .HasOne(m => m.SubCategory)
                    .WithMany(m => m.SubCategoryGoods);

            modelBuilder.Entity<SubCategory>()
                    .HasKey(k => k.Id);




        }

    }
}
