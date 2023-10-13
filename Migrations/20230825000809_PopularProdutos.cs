using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitsGade.Migrations
{
    /// <inheritdoc />
    public partial class PopularProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
    "INSERT INTO Produtos (Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, IsProdutoPreferido, EmEstoque, CategoriaId) " +
    "VALUES " +
    "('Camisa Nike Sb', 'Produto alta qualidade', 'Produto alta qualidade', 19.99, 'url1.jpg', 'thumb_url1.jpg', 1, 1, 2), " +
    "('Camisa Polo Nike', 'Produto alta qualidade', 'Produto alta qualidade', 29.99, 'url2.jpg', 'thumb_url2.jpg', 0, 1, 2), " +
    "('Tenis Nike SB Force', 'Produto alta qualidade', 'Produto alta qualidade', 889.99, 'url3.jpg', 'thumb_url3.jpg', 1, 1, 1), " +
    "('Tênis Nike Air Max', 'Produto alta qualidade', 'Produto alta qualidade', 739.99, 'url4.jpg', 'thumb_url4.jpg', 0, 0, 1), " +
    "('Moletom Nike Swoosh Pullove Hoodie', 'Produto alta qualidade', 'Produto alta qualidade', 149.99, 'url5.jpg', 'thumb_url5.jpg', 1, 1, 3);");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Produtos");
        }
    }
}
