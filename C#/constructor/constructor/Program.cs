namespace constructor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Carro carro = new Carro("Fiat", "Uno", "ABC-123", "Preto");
            Console.WriteLine(carro.mostrarCarro());

            Console.ReadKey();
        }
    }
}