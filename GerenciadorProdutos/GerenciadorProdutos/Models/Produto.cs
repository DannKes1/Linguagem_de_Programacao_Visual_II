namespace GerenciadorProdutos.Models;

public class Produto
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public decimal Preco { get; set; }
    public DateTime DataCriacao { get; set; }
    public required string Categoria { get; set; }
    public bool Ativo { get; set; }
    public required List<string> Tags { get; set; }

  
    public int DiasNoSistema => DateTime.Now > DataCriacao ? (DateTime.Now - DataCriacao).Days : 0;
}