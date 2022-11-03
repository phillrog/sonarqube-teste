using Moq;
using System.Text;

namespace Calculadora.Tests
{
    public class CalculadoraServiceTest
    {
        private readonly int _resultadoEsperado;
        private readonly CalculadoraService _calculadoraService;
        private readonly Mock<ICalculadoraService> _calculadoraServiceMock;

        public CalculadoraServiceTest()
        {
            _resultadoEsperado = 0;
            _calculadoraServiceMock = new Mock<ICalculadoraService>();
            _calculadoraService = new CalculadoraService();
        }

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        [TestCase(-1, -2)]
        [TestCase(-1, -100)]
        [TestCase(-19999, -100)]
        [TestCase(-991, -100)]
        public void DeveSomarNumeroNegativo(int a, int b)
        {
            var resultado = _calculadoraService.Somar(a, b);
            Assert.That(_resultadoEsperado, Is.GreaterThan(resultado), "Não é valor positivo");
        }

        [Test]
        [TestCase(-10, -2)]
        [TestCase(-101, -100)]
        [TestCase(-19999, -10000)]
        [TestCase(-991, -100)]
        public void DeveSubtrairNumeroNegativo(int a, int b)
        {
            var resultado = _calculadoraService.Subtrair(a, b);
            Assert.That(_resultadoEsperado, Is.GreaterThan(resultado), "Não é valor negativo");
        }

        [Test]
        public void NaoDeveDividirNumeroPorZero()
        {
            var a = 100;
            var b = 0;

            Assert.Throws<DivideByZeroException>(() => _calculadoraService.Dividir(a, b));
        }

        [Test]
        [TestCase(-1, -2)]
        [TestCase(-1, -100)]
        [TestCase(-19999, -100)]
        [TestCase(-991, -100)]
        public void DeveMultiplicarNumeroNegativo(int a, int b)
        {

            var resultado = _calculadoraService.Multiplicar(a, b);
            Assert.That(resultado, Is.GreaterThan(_resultadoEsperado), "É valor positivo");
        }

        [Test]
        public void DeveMockarDemonstracao()
        {
            var stringExperado = "Somar 1 + 1 = 100\r\nSubtrair 10 - 1 = 45\r\nDividir 100 / 10 = 0\r\nMultiplicar 100 * 100 = 999\r\n";
            _calculadoraServiceMock.Setup((a) => a.Somar(It.IsAny<int>(), It.IsAny<int>())).Returns(() => 100);
            _calculadoraServiceMock.Setup((a) => a.Subtrair(It.IsAny<int>(), It.IsAny<int>())).Returns(() => 2);
            _calculadoraServiceMock.Setup((a) => a.Subtrair(It.IsAny<int>(), It.IsAny<int>())).Returns(() => 45);
            _calculadoraServiceMock.Setup((a) => a.Multiplicar(It.IsAny<int>(), It.IsAny<int>())).Returns(() => 999);

            _calculadoraServiceMock.Setup((a) => a.Desmonstracao(It.IsAny<int>(), It.IsAny<int>())).Returns(() =>
            {
                var str = new StringBuilder();
                str.AppendLine($"Somar 1 + 1 = {_calculadoraServiceMock.Object.Somar(It.IsAny<int>(), It.IsAny<int>())}");
                str.AppendLine($"Subtrair 10 - 1 = {_calculadoraServiceMock.Object.Subtrair(It.IsAny<int>(), It.IsAny<int>())}");
                str.AppendLine($"Dividir 100 / 10 = {_calculadoraServiceMock.Object.Dividir(It.IsAny<int>(), It.IsAny<int>())}");
                str.AppendLine($"Multiplicar 100 * 100 = {_calculadoraServiceMock.Object.Multiplicar(It.IsAny<int>(), It.IsAny<int>())}");
                return str.ToString();
            });

            var retorno = _calculadoraServiceMock.Object.Desmonstracao(100, 100);

            _calculadoraServiceMock.Verify((a) => a.Somar(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            _calculadoraServiceMock.Verify((a) => a.Subtrair(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            _calculadoraServiceMock.Verify((a) => a.Subtrair(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            _calculadoraServiceMock.Verify((a) => a.Multiplicar(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            _calculadoraServiceMock.Verify((a) => a.Desmonstracao(It.IsAny<int>(), It.IsAny<int>()), Times.Once);            

            Mock.VerifyAll();
            Assert.That(retorno, Is.EqualTo(stringExperado), "Retorno inválido");
        }
    }
}