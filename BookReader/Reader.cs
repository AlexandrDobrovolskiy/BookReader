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
         *  size 1-7
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
                case "find":
                    LinkedList<int> matches = Search(args[1]);
                    if (matches.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        var current = matches.First;
                        DisplayPage(current.Value);
                        Console.WriteLine("Use commands \"next\" or \"prev\" to find more, and \"exit\" to exit the search.");
                        String input = Console.ReadLine();
                        while (input != null && !input.Equals("exit"))
                        {
                            if (input.Contains("next"))
                            {
                                if (current.Next != null)
                                {
                                    DisplayPage(current.Next.Value);
                                    current = current.Next;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else if (input.Contains("prev"))
                            {
                                if (current.Previous != null)
                                {
                                    DisplayPage(current.Previous.Value);
                                    current = current.Previous;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            Console.WriteLine("Use commands \"next\" or \"prev\" to find more, and \"exit\" to exit the search.");
                            input = Console.ReadLine();
                        }
                    }
                    break;
                case "size":
                    int nSize = int.Parse(args[1]);
                    if (nSize > 0 && nSize < 8)
                    {
                        _book.Update(nSize);
                    }
                    break;
                default:
                    break;
            }
        
        }

        private LinkedList<int> Search(String pattern)
        {
            LinkedList<int> matches = new LinkedList<int>();

            for (int i = 0; i < _book.Pages.Count; i++)
            {
                if (_book.GetPage(i).ToString().Contains(pattern))
                {
                    matches.AddLast(i);
                }    
            }

            return matches;
        }

        bool DisplayPage(int index)
        {
            Console.Clear();

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
                DisplayPage(currentPage);
                ReadCommand();
            }
        }
    }
}
