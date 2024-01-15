using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KitsGade.Controllers
{
    [AllowAnonymous]
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
