using Property.SharedKernel.Core;
using Property.SharedKernel.ValueObjects;
using Xunit;
namespace Property.Test.ValueObjects
{
    public class PrecioValueTest
    {
        [Fact]
        public void ValorMayorACero()
        {
            int valorEsperado = 10;
            PrecioValue valorVerificar = new PrecioValue(valorEsperado);
            Assert.Equal(valorEsperado, valorVerificar.Value);

        }
       
        [Fact]
        public void ValorMenorACero()
        {
            int valorEsperado = -5;
            Assert.Throws<BussinessRuleValidationException>(()=>new PrecioValue(valorEsperado));

        }
    }
}