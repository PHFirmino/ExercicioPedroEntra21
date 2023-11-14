namespace Abstracao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Animal animal = new Animal(); Não consigo acessar

            Cachorro cachorro = new Cachorro();
            cachorro.dormir();
            cachorro.sono();

            Console.ReadKey();
        }
    }
}