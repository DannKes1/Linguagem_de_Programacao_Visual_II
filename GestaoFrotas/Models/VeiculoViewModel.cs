using GestaoFrotas.Models.Enums;
using GestaoFrotas.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace GestaoFrotas.Models
{
    public class VeiculoViewModel : IValidatableObject
    {
        [Display(Name = "Placa")]
        [Required(ErrorMessage = "O campo Placa é obrigatório.")]
        [RegularExpression(@"^[A-Z]{3}[0-9][A-Z][0-9]{2}$", ErrorMessage = "A placa deve estar no padrão Mercosul (ABC1D23).")]
        [PlacaUnica] // Atributo customizado
        public string Placa { get; set; }

        [Display(Name = "Renavam")]
        [Required(ErrorMessage = "O campo Renavam é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Renavam deve conter 11 dígitos.")]
        [RenavamValido] // Atributo customizado
        public string Renavam { get; set; }

        [Display(Name = "Chassi")]
        [Required(ErrorMessage = "O campo Chassi é obrigatório.")]
        [RegularExpression(@"^[A-HJ-NPR-Z0-9]{17}$", ErrorMessage = "O Chassi deve ter 17 caracteres alfanuméricos e não pode conter as letras I, O ou Q.")]
        public string Chassi { get; set; }

        [Display(Name = "Ano de Fabricação")]
        [Required(ErrorMessage = "O ano de fabricação é obrigatório.")]
        [Range(1980, 2025, ErrorMessage = "O ano de fabricação deve ser entre 1980 e o ano atual (2025).")] // Ajuste o ano atual conforme necessário
        public int AnoFabricacao { get; set; }

        [Display(Name = "Ano do Modelo")]
        [Required(ErrorMessage = "O ano do modelo é obrigatório.")]
        [Range(1980, 2026, ErrorMessage = "O ano do modelo é inválido.")] // Ano atual + 1
        public int AnoModelo { get; set; }

        [Display(Name = "Tipo de Combustível")]
        [Required(ErrorMessage = "Selecione o tipo de combustível.")]
        public TipoCombustivel TipoCombustivel { get; set; }

        [Display(Name = "Valor do Seguro")]
        [RequiredIf(nameof(AnoModelo), 2010, ErrorMessage = "O Valor do Seguro é obrigatório para veículos com ano do modelo superior a 2010.")]
        [Range(500, double.MaxValue, ErrorMessage = "O valor mínimo do seguro é R$ 500.")]
        public decimal? ValorSeguro { get; set; }

        [Display(Name = "Nome do Proprietário")]
        [Required(ErrorMessage = "O nome do proprietário é obrigatório.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "O nome deve ter entre 6 e 100 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "O nome deve conter apenas letras e espaços.")]
        public string NomeProprietario { get; set; }

        // Método para validações complexas que envolvem mais de uma propriedade
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (AnoModelo < AnoFabricacao)
            {
                yield return new ValidationResult(
                    "O Ano do Modelo não pode ser menor que o Ano de Fabricação.",
                    new[] { nameof(AnoModelo) }
                );
            }
        }
    }
}