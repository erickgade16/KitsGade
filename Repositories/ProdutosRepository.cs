using KitsGade.Context;
using KitsGade.Models;
using KitsGade.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KitsGade.Repositories
{
    public class ProdutosRepository : IProdutosRepository
    {
        private readonly AppDbContext _context;

        public ProdutosRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Produto> Produtos => _context.Produtos.Include(c => c.Categoria);
        public IEnumerable<Produto> ProdutosPreferidos => _context.Produtos.
            Where(l => l.IsProdutoPreferido).
            Include(c => c.Categoria);

        public Produto GetProdutoById(int produtoId)
        {
            return _context.Produtos.FirstOrDefault(l => l.ProdutoId == produtoId);
        }
    }
}
