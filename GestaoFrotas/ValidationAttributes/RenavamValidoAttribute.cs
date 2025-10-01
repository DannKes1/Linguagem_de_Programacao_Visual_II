using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GestaoFrotas.ValidationAttributes
{
    public class RenavamValidoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var renavam = value as string;
            if (string.IsNullOrEmpty(renavam))
            {
                return ValidationResult.Success; // A validação de 'Required' cuida disso.
            }

            // Remove caracteres não numéricos
            renavam = new string(renavam.Where(char.IsDigit).ToArray());

            if (renavam.Length != 11)
            {
                return new ValidationResult("Renavam deve conter 11 dígitos.");
            }

            // Cálculo do Dígito Verificador
            var renavamSemDigito = renavam.Substring(0, 10);
            var renavamReverso = new string(renavamSemDigito.Reverse().ToArray());
            
            var soma = 0;
            var multiplicadores = new[] { 2, 3, 4, 5, 6, 7, 8, 9, 2, 3 };

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(renavamReverso[i].ToString()) * multiplicadores[i];
            }

            var resto = soma % 11;
            var digitoCalculado = 11 - resto;
            
            if (digitoCalculado >= 10)
            {
                digitoCalculado = 0;
            }

            var digitoInformado = int.Parse(renavam.Substring(10, 1));

            if (digitoCalculado == digitoInformado)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("O dígito verificador do Renavam é inválido.");
        }
    }
}