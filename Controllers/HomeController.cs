using KitsGade.Models;
using KitsGade.Repositories.Interfaces;
using KitsGade.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KitsGade.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IProdutosRepository _produtosRepository;

        public HomeController(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }
        //private readonly ILogger<HomeController> _logger;
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                ProdutosPreferidos = _produtosRepository.ProdutosPreferidos
            };
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}