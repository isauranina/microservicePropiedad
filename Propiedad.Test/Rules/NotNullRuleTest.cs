using Restaurant.SharedKernel.Rules;

namespace Propiedad.Test.Rules
{
    public class NotNullRuleTest
    {


        [Theory]
        [InlineData(null, false)]
        [InlineData("hola", true)]
        public void ValorNulo(string valorEsperado, bool resultadoEsperado)
        {

            NotNullRule rule = new NotNullRule(valorEsperado);
            bool esValido = rule.IsValid();
            Assert.Equal(resultadoEsperado, esValido);

        }


    }
}
