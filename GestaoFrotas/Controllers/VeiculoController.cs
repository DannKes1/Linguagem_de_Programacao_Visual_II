using GestaoFrotas.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoFrotas.Controllers
{
    public class VeiculoController : Controller
    {
        // Ação para exibir o formulário de cadastro (GET)
        [HttpGet]
        public IActionResult Cadastrar()
        {
            var model = new VeiculoViewModel();
            return View(model);
        }

        // Ação para processar os dados do formulário (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(VeiculoViewModel model)
        {
            // Verifica se o modelo passou em todas as validações (DataAnnotations)
            if (ModelState.IsValid)
            {
                // Se for válido, processa os dados (ex: salvar no banco)
                // Aqui, apenas exibimos uma mensagem de sucesso para demonstração.
                TempData["SuccessMessage"] = $"Veículo placa {model.Placa} cadastrado com sucesso!";
                
                // Redireciona para uma página de sucesso ou para o formulário limpo
                return RedirectToAction("Cadastrar");
            }

            // Se o modelo for inválido, retorna para a mesma View com os dados preenchidos
            // e as mensagens de erro.
            return View(model);
        }
    }
}