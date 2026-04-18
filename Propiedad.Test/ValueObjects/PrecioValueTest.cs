using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.ValueObjects;
using Xunit;
namespace Propiedad.Test.ValueObjects
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