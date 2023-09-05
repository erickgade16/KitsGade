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

        public IActionResult List()
        {
            //var produtos = _produtosRepository.Produtos;
            //return View(produtos);
            var produtoListViewModel = new ProdutoListViewModel();
            produtoListViewModel.Produtos = _produtosRepository.Produtos;
            produtoListViewModel.CategoriaAtual = "Categoria Atual";
            return View(produtoListViewModel);
        }
    }
}
