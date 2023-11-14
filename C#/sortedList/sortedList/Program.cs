namespace sortedList
{
    internal class Program
    {
        static void Main(string[] args)
        {

            colecaoKeyValue();

            Console.ReadKey();
        }
        static void colecaoKeyValue()
        {
            SortedList<string, string> keyValue = new SortedList<string, string>();
            keyValue.Add("txt", "notepad.exe");
            keyValue.Add("doc", "winword.exe");

            Console.WriteLine(keyValue.Values.ToArray()[0]);
            Console.WriteLine(keyValue.Keys.ToArray()[0]);

            Object[] valores = keyValue.Values.ToArray();

            //for (int i = 0; i < valores.Length; i++) 
            //{
            //    Console.WriteLine(valores[i]);
            //}

            foreach (KeyValuePair<string, string> pair in keyValue)
            {
                Console.WriteLine(pair.Key);
                Console.WriteLine(pair.Value);
            }
        }
    }
}