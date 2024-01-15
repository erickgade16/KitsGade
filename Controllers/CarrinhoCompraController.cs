using KitsGade.Models;
using KitsGade.Repositories.Interfaces;
using KitsGade.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KitsGade.Controllers
{
    [Authorize]
    public class CarrinhoCompraController : Controller
    {
        private readonly IProdutosRepository _produtosRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IProdutosRepository produtosRepository, CarrinhoCompra compinhoCompra)
        {
            _produtosRepository = produtosRepository;
            _carrinhoCompra = compinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal(),
            };

            return View(carrinhoCompraVM);
        }
        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int produtoId)
        {
            var produtoSelecionado = _produtosRepository.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            if (produtoSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(produtoSelecionado);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoverItemNoCarrinhoCompra(int produtoId)
        {
            var produtoSelecionado = _produtosRepository.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            if (produtoSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(produtoSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}
