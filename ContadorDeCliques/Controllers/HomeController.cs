using ContadorDeCliques.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContadorDeCliques.Controllers
{
    public class HomeController : Controller
    {

        private static int _contadorDeCliques = 0;

   
        [HttpGet]
        public IActionResult Index()
        {
       
            var modelo = new ContadorModel
            {
   
                Cliques = _contadorDeCliques
            };
            
    
            return View(modelo);
        }


        [HttpPost]
        public IActionResult Contar()
        {
            _contadorDeCliques++;
            
            return RedirectToAction("Index");
        }
    }
}