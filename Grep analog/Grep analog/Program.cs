using System;
using System.Linq;
using System.IO;

//search globally for lines matching the regular expression, and print them

namespace Grep_analog
{
    internal class Program
    {
        private static string path = "C:/";
        private static string check;

        private static void Main(string[] args)
        {
            Console.WriteLine(
                "-----------------------\nPlease enter grep expression:\n\nExample:\ngrep text text.txt\ngrep text C:/text.txt\ngrep text\n\n\nYou can change during catalog with using command cd\n\nExample:\ncd /Program Files\n-----------------------\n");
            while (true)
            {
                try
                {
                    Console.Write(path + ">>>");
                    string[] input = Parser(Console.ReadLine());
                    Console.WriteLine("\n");
                    if (input[0] == "grep")
                    {
                        check = "Данная подстрока не найдена\n";
                        if (input.Length == 2)
                        {
                            foreach (string filename in Directory.GetFiles(@path))
                                Search(input[1], filename);
                        }
                        else if (File.Exists(@input[2]))
                        {
                            Search(input[1], input[2]);
                        }
                        else if (File.Exists(@path + @input[2]))
                        {
                            Search(input[1], path + input[2]);
                        }
                        else if (Directory.Exists(@input[2]))
                        {
                            string[] fileInput = Directory.GetFiles(@input[2]);
                            foreach (string filename in fileInput)
                            {
                                Search(input[1], filename);
                            }
                        }
                        else if (Directory.Exists(@path + @input[2]))
                        {
                            string[] fileInput = Directory.GetFiles(@path + @input[2]);
                            foreach (string filename in fileInput)
                                Search(input[1], filename);
                        }
                        else
                        {
                            Console.WriteLine("Выбранный путь не существует");
                        }
                        Console.WriteLine(check);
                    }
                    else if (input[0] == "cd")
                    {
                        if (Directory.Exists(@path + @input[1]))
                        {
                            path = @path + @input[1];
                        }
                        else if (Directory.Exists(@input[1]))
                        {
                            path = input[1];
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка при вводе");
                }
            }
        }

        private static void Search(string word, string path)
        {
            StreamReader str = new StreamReader(@path);
            while (!str.EndOfStream)
            {
                string st = str.ReadLine();
                if (st.Contains(word) != false)
                {
                    check = "\n";
                    Console.WriteLine(st + "\t==>" + Path.GetFileName(@path));
                }
            }
            str.Close();
        }

        private static string[] Parser(string inputFull)
        {
            string[] input;
            if (inputFull.Contains("grep"))
            {
                if (inputFull.Contains('\''))
                {
                    input = inputFull.Split('\'');
                    input[0] = input[0].Trim();
                    input[2] = input[2].Trim();
                }
                else
                {
                    input = inputFull.Split(' ');
                    if (input.Length > 3)
                        for (int i = 2; i < input.Length - 1; i++)
                            input[2] += " " + input[i + 1];
                }
                return input;
            }
            else
            {
                input = new string[2] {"cd", inputFull.Remove(0, 3)};
                return input;
            }
        }
    }
}