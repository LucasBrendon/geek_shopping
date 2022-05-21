using Microsoft.EntityFrameworkCore.Migrations;

namespace GeekShopping.ProductAPI.Migrations
{
    public partial class PopulaBb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[,]
                {
                    { 4L, "Camiseta", "Camiseta ciza", "https://cf.shopee.com.br/file/90c8d140e4df5886b7d1b266ab11714f", "Mamonas", 69.9m },
                    { 5L, "Camiseta", "Camiseta ciza", "https://img.elo7.com.br/product/zoom/1EAC4D6/camiseta-rock-guitarrista-t-shirt.jpg", "Rock", 69.9m },
                    { 6L, "Camiseta", "Camiseta ciza", "https://hmrock.com.br/wp-content/uploads/2018/12/caveira.jpg", "Rock", 69.9m },
                    { 7L, "Camiseta", "Camiseta ciza", "https://cea.vtexassets.com/arquivos/ids/22173183/Camiseta-Masculina--Rock-n--Roll--Guitarra-Flocada-Manga-Curta-Gola-Careca-Preta-9966708-Preto_2.jpg?v=637430282968630000", "Guitar", 69.9m },
                    { 8L, "Camiseta", "Camiseta ciza", "https://images.fatum.com.br/site/produtos/123.jpg?losslevel=1&v=10.4", "Kiss", 69.9m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 8L);
        }
    }
}
