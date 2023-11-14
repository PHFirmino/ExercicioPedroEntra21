namespace carroExercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Carro carro = new Carro();
            carro.placa = "ABC-123";
            carro.marca = "Fiat";
            carro.modelo = "Uno";
            carro.cor = "Preto";

            Console.WriteLine(carro.display());
            Console.ReadKey();
        }
    }
}