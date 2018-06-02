using System;
using System.Collections.Generic;
using System.Text;

namespace BookReader
{
    class Reader
    {
        private Book _book;
        private int currentPage;

        public Reader(Book book)
        {
            _book = book;
        }

        /*  goto {page number}
         *  find "{substr}"
         *  size 
         */
        private void ReadCommand()
        {
            String[] args= Console.ReadLine()?.Split(' ');

            switch (args?[0])
            {
                case "goto":
                    if (args[1] == "next")
                    {
                        currentPage++;
                    }
                    else if (args[1] == "prev")
                    {
                        currentPage--;
                    }
                    else
                    {
                        currentPage = int.Parse(args[1]) - 1;
                    }
                    break;
                default:
                    break;
            }
        
        }

        bool DisplayPage(int index)
        {
            if (index < 0 || index > _book.Pages.Count)
            {
                Console.WriteLine($"There is no {++index} page. There is only {_book.Pages.Count} pages !");
                return false;
            }

            Console.WriteLine($"Page {index + 1} \t\t\t {_book.Pages.Count} at all\n");
            Console.WriteLine(_book.GetPage(index).ToString());

            return true;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                DisplayPage(currentPage);
                ReadCommand();
            }
        }
    }
}
