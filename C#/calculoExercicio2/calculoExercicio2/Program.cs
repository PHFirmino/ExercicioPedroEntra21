namespace calculoExercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculo calculo = new Calculo();
            calculo.n1 = 1;
            calculo.n2 = 2;

            Console.WriteLine(calculo.adicao());
            Console.WriteLine(calculo.subtracao());
            Console.WriteLine(calculo.divisao());
            Console.WriteLine(calculo.multiplicacao());
        }
    }
}