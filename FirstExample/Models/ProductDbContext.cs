namespace FirstExample.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProductDbContext : DbContext
    {
        public ProductDbContext()
            : base("name=ProductDbContext")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryOfProduct> categoryOfProducts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
