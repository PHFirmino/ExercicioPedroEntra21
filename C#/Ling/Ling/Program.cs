using System.Collections.Generic;
using System.Xml.Serialization;
using static Ling.Program;
using static System.Formats.Asn1.AsnWriter;

namespace Ling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] array = { 1, 3, 4, 5, 6};

            //pares(array);
            //impares(array);
            mostrar();
            mostrarAprovados();
            mostrarReprovados();
            mostrarMaiorNota();
            mostrarMenorNota();
            mostrarMenorMedia();
            mostrarMaiorMedia();
        }
        //static void pares(int[] array)
        //{
        //    var pares = from arrayItem in array
        //                  where (arrayItem % 2) == 0
        //                  select arrayItem;

        //    Console.WriteLine(pares.Count());

        //    foreach (var item in pares)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}
        //static void impares(int[] array)
        //{
        //    var impares = from arrayItem in array
        //                  where (arrayItem % 2) != 0
        //                  select arrayItem;

        //    foreach (var item in impares)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}

        public class Student
        {

            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;

        }

        static List<Student> students = new List<Student>()
        {
            new Student { First = "Svetlana", Last = "Omelchenko", ID = 111, Scores = new List<int> { 97, 92, 81, 60 } },
            new Student { First = "Claire", Last = "O'Donnell", ID = 112, Scores = new List<int> { 75, 84, 91, 39 } },
            new Student { First = "Sven", Last = "Mortensen", ID = 113, Scores = new List<int> { 88, 94, 65, 91 } },
            new Student { First = "Cesar", Last = "Garcia", ID = 114, Scores = new List<int> { 97, 89, 85, 82 } },
            new Student { First = "Debra", Last = "Garcia", ID = 115, Scores = new List<int> { 35, 72, 91, 70 } },
            new Student { First = "Fadi", Last = "Fakhouri", ID = 116, Scores = new List<int> { 99, 86, 90, 94 } },
            new Student { First = "Hanying", Last = "Feng", ID = 117, Scores = new List<int> { 93, 92, 80, 87 } },
            new Student { First = "Hugo", Last = "Garcia", ID = 118, Scores = new List<int> { 92, 90, 83, 78 } },
            new Student { First = "Lance", Last = "Tucker", ID = 119, Scores = new List<int> { 68, 79, 88, 92 } },
            new Student { First = "Terry", Last = "Adams", ID = 120, Scores = new List<int> { 99, 82, 81, 79 } },
            new Student { First = "Eugene", Last = "Zabokritski", ID = 121, Scores = new List<int> { 96, 85, 91, 60 } },
            new Student { First = "Michael", Last = "Tucker", ID = 122, Scores = new List<int> { 94, 92, 91, 91 } }
        };

        static void mostrar()
        {
            IEnumerable<Student> studentQuery =
            from student in students
            where student.Scores[0] > 90
            orderby student.Last descending select student;

            foreach (Student student in studentQuery)
            {
                Console.WriteLine("{0}, {1}", student.Last, student.First);
            }
        }
        static void mostrarAprovados()
        {
            IEnumerable<Student> studentQuery =
            from student in students
            where student.Scores.Sum() / 4 > 70
            select student;

            foreach (Student student in studentQuery)
            {
                Console.WriteLine("Aprovados: {0}, {1}", student.Last, student.First);
            }
        }
        static void mostrarReprovados()
        {
            IEnumerable<Student> studentQuery =
            from student in students
            where student.Scores.Sum() / 4 < 70
            select student;

            foreach (Student student in studentQuery)
            {
                Console.WriteLine("Reprovados: {0}, {1}", student.Last, student.First);
            }
        }
        static void mostrarMaiorNota()
        {
            IEnumerable<Student> studentQuery =
            from student in students
            orderby student.Scores.Max() descending
            select student;

            foreach (Student student in studentQuery)
            {
                Console.WriteLine("Maior nota: {0}, {1}, {2}", student.Last, student.First, student.Scores.Max());
                break;
            }
        }
        static void mostrarMenorNota()
        {
            IEnumerable<Student> studentQuery =
            from student in students
            orderby student.Scores.Min() ascending
            select student;

            foreach (Student student in studentQuery)
            {
                Console.WriteLine("Menor Média: {0}, {1}, {2}", student.Last, student.First, student.Scores.Min());
                break;
            }
        }
        static void mostrarMenorMedia()
        {
            IEnumerable<Student> studentQuery =
            from student in students
            orderby (student.Scores.Sum() / 4 < 70) descending
            select student;

            foreach (Student student in studentQuery)
            {
                Console.WriteLine($"Menor Média: {student.Last} {student.First} {student.Scores.Sum() / 4}");
                break;
            }
        }
        static void mostrarMaiorMedia()
        {
            IEnumerable<Student> studentQuery =
            from student in students
            orderby (student.Scores.Sum() / 4 > 70) ascending
            select student;

            Student student1 = new Student();

            foreach (Student student in studentQuery)
            {
                student1 = student;
            }

            Console.WriteLine($"Maior Média: {student1.Last} {student1.First} {student1.Scores.Sum() / 4}");
        }
    }
}