using KitsGade.Models;
using KitsGade.Repositories.Interfaces;
using KitsGade.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KitsGade.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutosRepository _produtosRepository;

        public ProdutoController(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Produto> produtos;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                produtos = _produtosRepository.Produtos.OrderBy(l => l.ProdutoId);
                categoriaAtual = "Todos os produtos";
            }
            else
            {
                if(string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    produtos = _produtosRepository.Produtos.Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
                        .OrderBy(l => l.ProdutoId);
                }
                else
                {
                    produtos = _produtosRepository.Produtos.Where(l => l.Categoria.CategoriaNome.Equals("Tênis"))
                        .OrderBy(l => l.ProdutoId);
                }
                categoriaAtual = categoria;
            }
            var produtoListViewModel = new ProdutoListViewModel
            {
                Produtos = produtos,
                CategoriaAtual = categoriaAtual
            };

            
            return View(produtoListViewModel);
        }
    }
}
