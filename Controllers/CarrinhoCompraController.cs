using KitsGade.Models;
using KitsGade.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KitsGade.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IProdutosRepository _produtosRepository;
        private readonly CarrinhoCompra _compinhoCompra;

        public CarrinhoCompraController(IProdutosRepository produtosRepository, CarrinhoCompra compinhoCompra)
        {
            _produtosRepository = produtosRepository;
            _compinhoCompra = compinhoCompra;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
