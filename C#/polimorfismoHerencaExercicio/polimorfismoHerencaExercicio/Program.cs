namespace polimorfismoHerencaExercicio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MotoCorrida motoCorrida = new MotoCorrida("Ducat", "Pista", "Speed", 100);
            Console.WriteLine(motoCorrida.som());

            MotoNormal motoNormal = new MotoNormal("Honda", "Inox", 200, "Honda-200");
            Console.WriteLine(motoNormal.som());

            Console.ReadKey();
        }
    }
}