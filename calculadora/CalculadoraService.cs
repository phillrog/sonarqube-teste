using System.Text;

namespace calculadora
{
    public class CalculadoraService : ICalculadoraService
    {
        public int Somar(int a, int b) => a + b;
        public int Subtrair(int a, int b) => a - b;
        public int Dividir(int a, int b) => a / b;
        public int Multiplicar(int a, int b) => (a) * (b);

        public string Desmonstracao(int a, int b)
        {
            return $"Somar 1 + 1 = {Somar(a, b)}\r\nSubtrair 10 - 1 = {Subtrair(a, b)}\r\nDividir 100 / 10 = {Dividir(a, b)}\r\nMultiplicar 100 * 100 = {Multiplicar(a, b)}\r\n";
        }

        public double Potencia(double a, double b)
        {
            return Math.Pow(a, b);
        }
    }
}
