namespace Herenca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Carro carro = new Carro();
            carro.Marca = "Fiat";
            carro.Modelo = "Uno";

            carro.barulho();

            Cliente cliente = new Cliente();

            cliente.Name = "Pedro";
            cliente.Id = "123";
            cliente.Cpf = "111111";

            Console.WriteLine(cliente.mostrarPessoa());

            Console.ReadKey();
        }
    }
}