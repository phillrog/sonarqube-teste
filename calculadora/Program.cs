// See https://aka.ms/new-console-template for more information

using System.Diagnostics.CodeAnalysis;

namespace calculadora
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main(string[] args)
        {
            var calculadora = new CalculadoraService();
            Console.WriteLine(calculadora.Desmonstracao(100, 100));

            Console.WriteLine(calculadora.Potencia(10, 100));
        }
    }
}