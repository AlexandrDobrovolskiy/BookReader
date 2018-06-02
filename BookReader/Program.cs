using System;

namespace BookReader
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = System.IO.File.ReadAllText(@"C:\Users\Alexandr\Desktop\book.txt");

            Reader bookReader = new Reader(new Book(text));

            bookReader.Run();

            Console.ReadKey();
        }
    }
}
