using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitsGade.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaName, Descricao)"+
                "VALUES('Tênis','Produto de alta qualidade')");
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaName, Descricao)" +
               "VALUES('Camisa','Produto de alta qualidade')");
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaName, Descricao)" +
               "VALUES('Moletom','Produto de alta qualidade')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");

        }
    }
}
