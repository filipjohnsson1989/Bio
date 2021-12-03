using System;
using System.Collections.Generic;

namespace Bio
{
    class Program
    {

        static void Main(string[] args)
        {
            // Huvudmeny
            do
            {
                Console.WriteLine("Huvudmeny");
                Console.WriteLine("0: Stäng ner programmet!");
                Console.WriteLine("1: Ungdom eller pensionär");
                Console.WriteLine("2: Upprepa tio gånger!");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        throw new NotImplementedException();
                        break;
                    case "2":
                        throw new NotImplementedException();
                        break;
                    default:
                        Console.WriteLine("Det är felaktig input");
                        break;
                }
            } while (true);

        }
    }
}
