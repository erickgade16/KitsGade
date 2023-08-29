using KitsGade.Repositories.Interfaces;
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
            var produtos = _produtosRepository.Produtos;
            return View(produtos);
        }
    }
}
