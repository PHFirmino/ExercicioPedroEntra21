namespace modificadorDeAcesso
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Carro carro = new Carro();
            
            //Console.WriteLine(carro.marca); Não é possível ter acesso
            Console.WriteLine(carro.modelo);
        }
    }
}