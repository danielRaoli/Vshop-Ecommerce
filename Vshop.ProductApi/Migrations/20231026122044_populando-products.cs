using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vshop.ProductApi.Migrations
{
    public partial class populandoproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into products(Name,Price,Description,Stock,ImageUrl,CategoryId)" + "Values('caderno',12.75,'Caderno Capa Dura', 10,'Caderno.Jpg',1)");
            migrationBuilder.Sql("insert into products(Name,Price,Description,Stock,ImageUrl,CategoryId)" + "Values('Mochila',63.99,'Mochila com 4 bolsos', 5,'Mochila.Jpg',2)");
            migrationBuilder.Sql("insert into products(Name,Price,Description,Stock,ImageUrl,CategoryId)" + "Values('clip',5.0,'Clip para papel', 20,'Clip.Jpg',2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("remove from products");
        }
    }
}
