

using GerenciadorProdutos.Models;
using GerenciadorProdutos.ViewModels;
using System.Globalization;

namespace GerenciadorProdutos.Extensions;


public static class ProdutoExtensions
{

    public static ProdutoListagemItemViewModel ToListItemViewModel(this Produto produto)
    {
        return new ProdutoListagemItemViewModel
        {
            Id = produto.Id,
            Nome = produto.Nome,
            PrecoFormatado = produto.Preco.ToString("C", new CultureInfo("pt-BR")), // Moeda R$
            Categoria = produto.Categoria,
            Status = produto.Ativo ? "Ativo" : "Inativo", // Lógica do status
            TagsExibicao = string.Join(", ", produto.Tags), // Junta as tags
            Badge = produto.Preco > 1000 ? "Premium" : string.Empty // Lógica do badge
        };
    }

  
    public static ProdutoDetalhesViewModel ToDetalhesViewModel(this Produto produto, IEnumerable<Produto> todosOsProdutos)
    {
        var relacionados = todosOsProdutos
            .Where(p => p.Categoria == produto.Categoria && p.Id != produto.Id) // Mesma categoria, ID diferente
            .Take(3)
            .ToList();

        return new ProdutoDetalhesViewModel
        {
            NomeProduto = produto.Nome,
            PrecoFormatado = produto.Preco.ToString("C", new CultureInfo("pt-BR")),
            CategoriaExibicao = $"Categoria: {produto.Categoria}", // Adiciona o prefixo
            StatusAtivo = produto.Ativo,
            TempoNoSistema = $"{produto.DiasNoSistema} {(produto.DiasNoSistema == 1 ? "dia" : "dias")} no sistema",
            MensagemPromocional = produto.Preco > 100 ? "Produto Premium!" : "Oferta Especial!",
            TagsExibicao = string.Join(" | ", produto.Tags),
            Relacionados = relacionados
        };
    }
}