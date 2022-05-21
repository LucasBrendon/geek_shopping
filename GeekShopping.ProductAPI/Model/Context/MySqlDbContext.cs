using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context
{
    public class MySqlDbContext : DbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Mamonas",
                Price = new decimal(69.9),
                Description = "Camiseta ciza",
                ImageUrl = "https://cf.shopee.com.br/file/90c8d140e4df5886b7d1b266ab11714f",
                CategoryName = "Camiseta"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Rock",
                Price = new decimal(69.9),
                Description = "Camiseta ciza",
                ImageUrl = "https://img.elo7.com.br/product/zoom/1EAC4D6/camiseta-rock-guitarrista-t-shirt.jpg",
                CategoryName = "Camiseta"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Rock",
                Price = new decimal(69.9),
                Description = "Camiseta ciza",
                ImageUrl = "https://hmrock.com.br/wp-content/uploads/2018/12/caveira.jpg",
                CategoryName = "Camiseta"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                Name = "Guitar",
                Price = new decimal(69.9),
                Description = "Camiseta ciza",
                ImageUrl = "https://cea.vtexassets.com/arquivos/ids/22173183/Camiseta-Masculina--Rock-n--Roll--Guitarra-Flocada-Manga-Curta-Gola-Careca-Preta-9966708-Preto_2.jpg?v=637430282968630000",
                CategoryName = "Camiseta"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 8,
                Name = "Kiss",
                Price = new decimal(69.9),
                Description = "Camiseta ciza",
                ImageUrl = "https://images.fatum.com.br/site/produtos/123.jpg?losslevel=1&v=10.4",
                CategoryName = "Camiseta"
            });
        }
    }
}
