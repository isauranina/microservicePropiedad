using Property.SharedKernel.Core;
using Property.SharedKernel.ValueObjects;
using Xunit;
namespace Property.Test.ValueObjects
{
    public class CantidadValueTest
    {


       
        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        public void ValorMayorIgualCero(int valorEsperado)
        {

            CantidadValue valorVerificar = new CantidadValue(valorEsperado);
            Assert.Equal(valorEsperado, valorVerificar.Value);

        }

        [Fact]
        public void ValorMenorACero()
        {
            int valorEsperado = -5;
            Assert.Throws<BussinessRuleValidationException>(()=>new  CantidadValue(valorEsperado));

        }
        [Fact]
        public void DeEnteroACantidad()
        {
            int valorEsperado = 5;
            CantidadValue valorConvertido = valorEsperado;
            Assert.Equal(valorEsperado,valorConvertido.Value);
            

        }
        [Fact]
        public void DeCantidadAEntero()
        {
            CantidadValue valorEsperado = new CantidadValue(5);
            int valorConvertido = valorEsperado;         
            Assert.Equal(valorEsperado.Value, valorConvertido);


        }
    }
}