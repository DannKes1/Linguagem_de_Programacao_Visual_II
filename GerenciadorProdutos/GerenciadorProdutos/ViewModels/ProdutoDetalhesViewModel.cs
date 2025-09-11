namespace GerenciadorProdutos.ViewModels;
using GerenciadorProdutos.Models;

public class ProdutoDetalhesViewModel
{
    public string? NomeProduto { get; set; }
    public string? PrecoFormatado { get; set; }
    public string? CategoriaExibicao { get; set; }
    public bool StatusAtivo { get; set; }
    public string? TempoNoSistema { get; set; }
    public string? MensagemPromocional { get; set; }
    public string? TagsExibicao { get; set; }
    public IEnumerable<Produto> Relacionados { get; set; } = new List<Produto>();
}