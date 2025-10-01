using System.ComponentModel.DataAnnotations;

namespace GestaoFrotas.ValidationAttributes
{
    public class PlacaUnicaAttribute : ValidationAttribute
    {
        // Simulação de um repositório ou banco de dados em memória.
        // Em uma aplicação real, isso faria uma consulta no banco de dados.
        private static readonly List<string> PlacasCadastradas = new List<string> { "ABC1D23", "XYZ9E87" };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string placa)
            {
                // Convertemos para maiúsculas para garantir a comparação
                if (PlacasCadastradas.Contains(placa.ToUpper()))
                {
                    return new ValidationResult("A placa informada já está cadastrada.");
                }
            }

            return ValidationResult.Success;
        }
    }
}