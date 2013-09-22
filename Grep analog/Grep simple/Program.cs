using System;
using System.IO;

namespace Grep_simple
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------\nPlease enter grep expression:\n\nExample:\ngrep text C:/text.txt\n-----------------------\n");
            while (true)
            {
                Console.Write(">>>");
                string[] input = Console.ReadLine().Split(' ');
                StreamReader str = new StreamReader(@input[2]);
                //Переменная для фиксирования неудачного поиска
                string check = "It does not contain this string\n";
                while (!str.EndOfStream)
                {
                    string st = str.ReadLine();
                    if (st.Contains(input[1])!=false)
                    {
                        check = "\n";
                        Console.WriteLine(st);
                    }
                }
                Console.WriteLine(check);
            }
        }
    }
}