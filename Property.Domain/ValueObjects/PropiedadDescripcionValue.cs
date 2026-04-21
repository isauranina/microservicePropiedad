using Property.SharedKernel.Core;

namespace Property.Domain.ValueObjects
{
    public record PropiedadDescripcionValue : ValueObject
    {
        public string Value { get; }

        public PropiedadDescripcionValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new BussinessRuleValidationException("La descripción de la propiedad no puede estar vacía.");
            }
            if (value.Length > 500)
            {
                throw new BussinessRuleValidationException("La descripción de la propiedad no puede tener más de 500 caracteres.");
            }
            Value = value;
        }

        public static implicit operator string(PropiedadDescripcionValue value) => value.Value;
        public static implicit operator PropiedadDescripcionValue(string value) => new(value);
    }
}