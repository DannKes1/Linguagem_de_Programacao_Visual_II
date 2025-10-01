

namespace GerenciamentoProdutos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Categoria { get; set; }
        public bool EmEstoque { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}