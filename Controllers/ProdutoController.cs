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
               
                produtos = _produtosRepository.Produtos
                    .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                    .OrderBy(c => c.Nome);
                categoriaAtual = categoria;
            }
            var produtoListViewModel = new ProdutoListViewModel
            {
                Produtos = produtos,
                CategoriaAtual = categoriaAtual
            };


            return View(produtoListViewModel);
        }

        public IActionResult Details(int produtoId) 
        {
            var produto = _produtosRepository.Produtos.FirstOrDefault(l =>l.ProdutoId == produtoId);
            return View(produto);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Produto> produtos;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                produtos = _produtosRepository.Produtos.OrderBy(p=>p.ProdutoId);
                categoriaAtual = "Todos Produtos";
            }
            else
            {
                produtos = _produtosRepository.Produtos.Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));

                if(produtos.Any())
                { categoriaAtual = "Produtos"; }
                else
                { categoriaAtual = "Nenhum produto encontrado"; }
            }
            return View("~/Views/Produto/List.cshtml", new ProdutoListViewModel
            {
                Produtos = produtos,
                CategoriaAtual = categoriaAtual
            });
        }
    }
}