namespace Calculadora.Tests
{
    public class ProgramTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void DeveExecutar()
        {
            Assert.DoesNotThrow(() => Program.Main(Array.Empty<string>()), "Não executou a aplicação");
        }
    }
}