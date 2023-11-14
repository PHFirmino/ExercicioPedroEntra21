namespace encapsulamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Carro carro = new Carro();

            carro.Modelo = "Fiat";
            Console.WriteLine(carro.Modelo);

            Console.ReadKey();
        }
    }
}