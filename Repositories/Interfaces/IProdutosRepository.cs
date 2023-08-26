using KitsGade.Models;

namespace KitsGade.Repositories.Interfaces
{
    public interface IProdutosRepository
    {
        IEnumerable<Produto> Produtos { get; }
        IEnumerable<Produto> ProdutosPreferidos { get; }
        Produto GetProdutoById(int produtoId);
    }
}
