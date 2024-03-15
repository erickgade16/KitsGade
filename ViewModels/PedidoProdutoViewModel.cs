using KitsGade.Models;

namespace KitsGade.ViewModels
{
    public class ProdutoPedidoViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}
