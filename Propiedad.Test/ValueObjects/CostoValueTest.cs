using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.ValueObjects;
using Propiedad.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Test.ValueObjects
{
    public class CostoValueTest
    {

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        public void ValorMayorIgualCero(decimal valorEsperado)
        {

            CostoValue valorVerificar = new CostoValue(valorEsperado);
            Assert.Equal(valorEsperado, valorVerificar.Value);

        }

        [Fact]
        public void ValorMenorACero()
        {
            int valorEsperado = -5;
            Assert.Throws<BussinessRuleValidationException>(() => new CostoValue(valorEsperado));
        }
        [Fact]
        public void DeEnteroACantidad()
        {
            decimal valorEsperado = 5;
            CostoValue valorConvertido = valorEsperado;
            Assert.Equal(valorEsperado, valorConvertido.Value);


        }
        [Fact]
        public void DeCantidadAEntero()
        {
            CostoValue valorEsperado = new CostoValue(5);
            decimal valorConvertido = valorEsperado;
            Assert.Equal(valorEsperado.Value, valorConvertido);
        }
    }
}
