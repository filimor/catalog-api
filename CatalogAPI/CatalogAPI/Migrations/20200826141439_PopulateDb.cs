using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogAPI.Migrations
{
    public partial class PopulateDb : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categories(Name, ImageUrl) Values('Bebidas','http://www.macoratti.net/Imagens/1.jpg')");
            mb.Sql("Insert into Categories(Name, ImageUrl) Values('Lanches','http://www.macoratti.net/Imagens/2.jpg')");
            mb.Sql("Insert into Categories(Name, ImageUrl) Values('Sobremesas','http://www.macoratti.net/Imagens/3.jpg')");

            mb.Sql("Insert into Products(Name,Description,Price,ImageUrl,Stock,RegistrationDate,CategoryId) " +
                   "Values('Coca-Cola Diet','Refrigerante de Cola 350 ml',5.45,'http://www.macoratti.net/Imagens/coca.jpg',50,now()," +
                   "(Select Id from Categories where Name='Bebidas'))");

            mb.Sql("Insert into Products(Name,Description,Price,ImageUrl,Stock,RegistrationDate,CategoryId) " +
                   "Values('Lanche de Atum','Lanche de Atum com maionese',8.50,'http://www.macoratti.net/Imagens/atum.jpg',10,now()," +
                   "(Select Id from Categories where Name='Lanches'))");

            mb.Sql("Insert into Products(Name,Description,Price,ImageUrl,Stock,RegistrationDate,CategoryId) " +
                   "Values('Pudim 100 g','Pudim de leite condensado 100g',6.75,'http://www.macoratti.net/Imagens/pudim.jpg',20,now()," +
                   "(Select Id from Categories where Name='Sobremesas'))");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categories");
            mb.Sql("Delete from Products");
        }
    }
}
