using KitsGade.Areas.Admin.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace KitsGade.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRelatorioVendasController : Controller
    {

        private readonly RelatorioVendasServicos relatorioVendasServicos;

        public AdminRelatorioVendasController(RelatorioVendasServicos _relatorioVendasServicos)
        {
            relatorioVendasServicos = _relatorioVendasServicos;
        }

        public IActionResult index()
        {
            return View();
        }

        public async Task<IActionResult> RelatorioVendasSimples(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = await relatorioVendasServicos.FindByDateAsync(minDate, maxDate);

            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("dd-MM-yyyy");
            ViewData["maxDate"] = maxDate.Value.ToString("dd-MM-yyyy");

            return View(resultado);
        }



    }
}

