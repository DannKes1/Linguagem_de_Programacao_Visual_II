using System.ComponentModel.DataAnnotations;

namespace GestaoFrotas.ValidationAttributes
{
    public class RequiredIfAttribute : ValidationAttribute
    {
        private readonly string _dependentProperty;
        private readonly int _triggerValue;

        public RequiredIfAttribute(string dependentProperty, int triggerValue)
        {
            _dependentProperty = dependentProperty;
            _triggerValue = triggerValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dependentPropertyInfo = validationContext.ObjectType.GetProperty(_dependentProperty);
            if (dependentPropertyInfo == null)
            {
                return new ValidationResult($"Propriedade desconhecida: {_dependentProperty}");
            }

            var dependentPropertyValue = (int)dependentPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            // Se a condição for atendida (AnoModelo > 2010)...
            if (dependentPropertyValue > _triggerValue)
            {
                // ...então o valor do campo atual (ValorSeguro) não pode ser nulo ou vazio.
                if (value == null || (value is string str && string.IsNullOrWhiteSpace(str)) || (value is decimal d && d <= 0))
                {
                    // Usa o ErrorMessage definido na ViewModel ou um padrão.
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }

            return ValidationResult.Success;
        }
    }
}