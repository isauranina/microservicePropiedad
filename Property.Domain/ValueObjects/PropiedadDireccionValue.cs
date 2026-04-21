using Property.SharedKernel.Core;

namespace Property.Domain.ValueObjects
{
    public record PropiedadDireccionValue : ValueObject
    {
        public string Value { get; }

        public PropiedadDireccionValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new BussinessRuleValidationException("La dirección de la propiedad no puede estar vacía.");
            }
            Value = value;
        }
        public static implicit operator string(PropiedadDireccionValue value) => value.Value;
        public static implicit operator PropiedadDireccionValue(string value) => new(value);
    }
}