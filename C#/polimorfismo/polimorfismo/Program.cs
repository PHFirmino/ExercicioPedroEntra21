namespace polimorfismo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Veiculo veiculo = new Veiculo();
            veiculo.som();

            Veiculo moto = new Moto();
            moto.som();

            Console.ReadKey();
        }
    }
}