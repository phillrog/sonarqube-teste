namespace calculadora
{
    public interface ICalculadoraService
    {
        public int Somar(int a, int b);
        public int Subtrair(int a, int b);
        public int Dividir(int a, int b);
        public int Multiplicar(int a, int b);
        public string Desmonstracao(int a, int b);
        public double Potencia(double a, double b);
    }
}