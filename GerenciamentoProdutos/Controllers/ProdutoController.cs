// Controllers/ProdutoController.cs

using GerenciamentoProdutos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace GerenciamentoProdutos.Controllers
{
    public class ProdutoController : Controller
    {
        // Lista estática para simular um banco de dados
        private static readonly List<Produto> _produtos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "Smartphone XYZ", Preco = 1999.99m, Categoria = "Eletrônicos", EmEstoque = true, DataCadastro = DateTime.Now.AddDays(-10) },
            new Produto { Id = 2, Nome = "Notebook Gamer", Preco = 6499.00m, Categoria = "Eletrônicos", EmEstoque = false, DataCadastro = DateTime.Now.AddDays(-5) },
            new Produto { Id = 3, Nome = "Camiseta Básica", Preco = 59.90m, Categoria = "Roupas", EmEstoque = true, DataCadastro = DateTime.Now.AddDays(-20) },
            new Produto { Id = 4, Nome = "Calça Jeans", Preco = 189.90m, Categoria = "Roupas", EmEstoque = true, DataCadastro = DateTime.Now.AddDays(-15) },
            new Produto { Id = 5, Nome = "Livro de Romance", Preco = 45.50m, Categoria = "Livros", EmEstoque = true, DataCadastro = DateTime.Now.AddDays(-30) },
            new Produto { Id = 6, Nome = "Manual Técnico", Preco = 120.00m, Categoria = "Livros", EmEstoque = false, DataCadastro = DateTime.Now.AddDays(-2) }
        };

        // =======================================================================
        // A) ViewResult Actions
        // =======================================================================

        // Exibe a lista de todos os produtos
        public IActionResult Index()
        {
            // Passa a lista de categorias para o dropdown de filtro na View
            ViewBag.Categorias = _produtos.Select(p => p.Categoria).Distinct().ToList();
            return View(_produtos);
        }

        // Mostra os detalhes de um produto específico
        public IActionResult Detalhes(int id)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound(); // Retorna um erro 404 se o produto não for encontrado
            }
            return View(produto);
        }

        // Filtra e exibe produtos por categoria
        public IActionResult Categoria(string categoria)
        {
            if (string.IsNullOrEmpty(categoria))
            {
                return RedirectToAction("Index");
            }
            var produtosFiltrados = _produtos.Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase)).ToList();
            ViewBag.CategoriaAtual = categoria;
            return View(produtosFiltrados);
        }

        // =======================================================================
        // B) JsonResult Actions
        // =======================================================================

        // Retorna todos os produtos em formato JSON
        public IActionResult ObterProdutosJson()
        {
            return Json(new { sucesso = true, dados = _produtos });
        }

        // Retorna um produto específico em formato JSON
        public IActionResult BuscarProduto(int id)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return Json(new { sucesso = false, mensagem = "Produto não encontrado." });
            }
            return Json(new { sucesso = true, dados = produto });
        }
        
        // Retorna produtos filtrados por categoria em formato JSON
        public IActionResult ProdutosPorCategoria(string categoria)
        {
            var produtosFiltrados = _produtos
                .Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                .ToList();
                
            return Json(new { sucesso = true, contagem = produtosFiltrados.Count, dados = produtosFiltrados });
        }

        // =======================================================================
        // C) FileResult Actions
        // =======================================================================

        // Gera e baixa um arquivo CSV com a lista de produtos
        public IActionResult ExportarCsv()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Id,Nome,Preco,Categoria,EmEstoque,DataCadastro"); // Cabeçalho

            foreach (var produto in _produtos)
            {
                builder.AppendLine($"{produto.Id},{produto.Nome},{produto.Preco},{produto.Categoria},{produto.EmEstoque},{produto.DataCadastro:yyyy-MM-dd}");
            }

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "produtos.csv");
        }

        // Gera e baixa um relatório em arquivo de texto (.txt)
        public IActionResult RelatorioTxt()
        {
            var builder = new StringBuilder();
            builder.AppendLine("========================================");
            builder.AppendLine("      RELATÓRIO DE PRODUTOS");
            builder.AppendLine("========================================");
            builder.AppendLine($"Data do Relatório: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            builder.AppendLine($"Total de Produtos Cadastrados: {_produtos.Count}");
            builder.AppendLine($"Total de Produtos em Estoque: {_produtos.Count(p => p.EmEstoque)}");
            builder.AppendLine("----------------------------------------");
            builder.AppendLine("PRODUTOS POR CATEGORIA:");
            
            var produtosPorCategoria = _produtos
                .GroupBy(p => p.Categoria)
                .Select(g => new { Categoria = g.Key, Quantidade = g.Count() });

            foreach (var grupo in produtosPorCategoria)
            {
                builder.AppendLine($"- {grupo.Categoria}: {grupo.Quantidade} produto(s)");
            }
            builder.AppendLine("========================================");

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/plain", "relatorio_produtos.txt");
        }

        // Gera e baixa um arquivo JSON completo com todos os produtos
        public IActionResult ExportarJson()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(_produtos, options);
            
            return File(Encoding.UTF8.GetBytes(jsonString), "application/json", "produtos.json");
        }
    }
}