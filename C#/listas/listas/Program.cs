namespace listas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("Pedro");
            list.Add("João");
            list.Remove("João");
            
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}