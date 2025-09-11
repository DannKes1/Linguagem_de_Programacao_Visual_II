

using GerenciadorProdutos.Extensions;
using GerenciadorProdutos.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorProdutos.Controllers;

public class ProdutoController : Controller
{
    
    private static readonly List<Produto> _produtosMock = new()
    {
        new Produto { Id = 1, Nome = "Smartphone X Pro", Preco = 1299.99M, DataCriacao = DateTime.Now.AddDays(-10), Categoria = "Eletrônicos", Ativo = true, Tags = new List<string> { "promo", "android" } },
        new Produto { Id = 2, Nome = "Fone de Ouvido Bluetooth T5", Preco = 199.50M, DataCriacao = DateTime.Now.AddDays(-30), Categoria = "Áudio", Ativo = true, Tags = new List<string> { "bluetooth", "oferta" } },
        new Produto { Id = 3, Nome = "Notebook Gamer Z", Preco = 4500.00M, DataCriacao = DateTime.Now.AddDays(-5), Categoria = "Eletrônicos", Ativo = false, Tags = new List<string> { "gamer", "16GB" } },
        new Produto { Id = 4, Nome = "Mouse Sem Fio M2", Preco = 89.90M, DataCriacao = DateTime.Now.AddDays(-60), Categoria = "Acessórios", Ativo = true, Tags = new List<string> { "ergonomico" } },
        new Produto { Id = 5, Nome = "Caixa de Som Portátil", Preco = 350.00M, DataCriacao = DateTime.Now.AddDays(-2), Categoria = "Áudio", Ativo = true, Tags = new List<string> { "portatil", "promo" } },
        new Produto { Id = 6, Nome = "Webcam 4K Ultra", Preco = 800.00M, DataCriacao = DateTime.Now.AddDays(-15), Categoria = "Acessórios", Ativo = true, Tags = new List<string> { "4k", "streaming" } },
        new Produto { Id = 7, Nome = "Monitor Gamer Curvo 27\"", Preco = 1899.00M, DataCriacao = DateTime.Now.AddDays(-22), Categoria = "Eletrônicos", Ativo = true, Tags = new List<string> { "gamer", "144hz" } }
    };
    
    public IActionResult Lista(string? categoria, string? ordenarPor = "preco_asc")
    {
        IEnumerable<Produto> produtosFiltrados = _produtosMock;

        
        if (!string.IsNullOrEmpty(categoria))
        {
            produtosFiltrados = produtosFiltrados.Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase));
        }

        
        switch (ordenarPor?.ToLower())
        {
            case "preco_desc":
                produtosFiltrados = produtosFiltrados.OrderByDescending(p => p.Preco);
                break;
            case "nome":
                produtosFiltrados = produtosFiltrados.OrderBy(p => p.Nome);
                break;
            default: 
                produtosFiltrados = produtosFiltrados.OrderBy(p => p.Preco);
                break;
        }

       
        var viewModel = produtosFiltrados.Select(p => p.ToListItemViewModel());

   
        ViewBag.Categorias = _produtosMock.Select(p => p.Categoria).Distinct().ToList();

        return View(viewModel);
    }
    

    public IActionResult Detalhes(int id)
    {

        var produto = _produtosMock.FirstOrDefault(p => p.Id == id);

        if (produto == null)
        {
            return NotFound(); 
        }

        
        var viewModel = produto.ToDetalhesViewModel(_produtosMock);

        return View(viewModel);
    }
}