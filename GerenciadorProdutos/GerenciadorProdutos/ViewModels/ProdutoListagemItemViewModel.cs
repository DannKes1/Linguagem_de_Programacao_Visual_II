namespace GerenciadorProdutos.ViewModels;

public class ProdutoListagemItemViewModel
{
    public int Id { get; set; } 
    
    public string? Nome { get; set; }
    public string? PrecoFormatado { get; set; }
    public string? Categoria { get; set; }
    public string? Status { get; set; }
    public string? TagsExibicao { get; set; }
    public string? Badge { get; set; }
}