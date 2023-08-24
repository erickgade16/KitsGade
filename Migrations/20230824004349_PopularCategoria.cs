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
            migrationBuilder.Sql("INSERT INTO Categorias(CategopriaNome)"+
                "VALUES('Tênis')");
            migrationBuilder.Sql("INSERT INTO Categorias(CategopriaNome)" +
               "VALUES('Camisa')");
            migrationBuilder.Sql("INSERT INTO Categorias(CategopriaNome)" +
               "VALUES('Moletom')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");

        }
    }
}
