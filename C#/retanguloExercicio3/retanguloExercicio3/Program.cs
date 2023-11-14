namespace retanguloExercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Retangulo retangulo = new Retangulo();
            retangulo.altura = 5;
            retangulo.comprimento = 10;

            Console.WriteLine(retangulo.mostrarPerimetro());
            Console.WriteLine(retangulo.mostrarArea());

            Console.ReadKey();
        }
    }
}