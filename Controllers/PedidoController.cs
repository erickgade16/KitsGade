using KitsGade.Models;
using KitsGade.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KitsGade.Controllers
{
    [Authorize]
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Pedido pedido) 
        {
            int totalItensPedido = 0;
            decimal precoTotalPedido = 0.0m;

            //obtem  os items do carrinho de compra
            List<CarrinhoCompraItem> items = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = items;

            //verificar se existem items no carrinho
            if (_carrinhoCompra.CarrinhoCompraItems.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio.");
            }

            //calcular o total de itens e total do pedido
            foreach (var item in items)
            {
                totalItensPedido += item.Quantidade;
                precoTotalPedido += (item.Produto.Preco * item.Quantidade);

            }


            //atribui os valores obtidos ao pedido
            pedido.TotalItensPedido = totalItensPedido;
            pedido.PedidoTotal = precoTotalPedido;


            //valida os dados do pedido
            if(ModelState.IsValid )
            {
                //cria pedido e os detalhes
                _pedidoRepository.CriarPedido(pedido);

                //definir mensagens ao cliente
                ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido!";
                //ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraItens();
                ViewBag.TotalPedido = precoTotalPedido;

                //limpar carrinho
                _carrinhoCompra.LimparCarrinho();

                //Exibe a view com  dados do cliente  e do pedido
                return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
            }
            return View(pedido);

        }
    }
}
