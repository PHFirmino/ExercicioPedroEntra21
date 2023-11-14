namespace linkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            colecaoLinkedList();

            Console.ReadKey();
        }
        static void colecaoLinkedList()
        {
            LinkedList<string> lista = new LinkedList<string>();
            lista.AddFirst("Pedro");
            lista.AddFirst("Maria");
            lista.AddLast("Lucas");

            mostrarLista(lista);

            LinkedListNode<string> x = lista.Find("Pedro");
            Console.WriteLine(x.Value);

            LinkedListNode<string> anterior = x.Previous;
            Console.WriteLine(anterior.Value);

            LinkedListNode<string> proximo = x.Next;
            Console.WriteLine(proximo.Value);

            lista.AddAfter(x, "João");
            lista.AddBefore(x, "Sandro");
        }
        static void mostrarLista(LinkedList<string> lista)
        {
            foreach (string item in lista)
            {
                Console.WriteLine(item);
            }
        }
    }
}