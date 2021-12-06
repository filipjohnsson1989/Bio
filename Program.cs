using Bio.Structs;
using Bio.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Bio
{
    class Program
    {
        private static Sell sell = new Sell();

        static void Main(string[] args)
        {
            do
            {
                // Huvudmeny
                ShowMainMenu();
                GetUserInput();
            } while (true);
        }



        private static void ShowMainMenu()
        {
            Console.WriteLine("Huvudmeny");
            Console.WriteLine("0: Stäng av");
            Console.WriteLine("1: Sälja enskild");
            Console.WriteLine("2: Upprepa tio gånger");
            Console.WriteLine("3: Hitta det tredje ordet");
            Console.WriteLine("4: Sälja till ett helt sällskap");
        }

        private static void GetUserInput()
        {
            var input = Tool<uint>.AskForAnInput(string.Empty, "ett val");
            switch (input)
            {
                case 0:
                    ClosePrograme();
                    break;
                case 1:
                    SellSingelTicket();
                    break;
                case 2:
                    RepeatTextTenTimes();
                    break;
                case 3:
                    FindTheThirdWord();
                    break;
                case 4:
                    SellGroupTeckets();
                    break;
                default:
                    WrongInput();
                    break;
            }
        }

        private static void ClosePrograme()
        {
            Console.WriteLine("Stängs");
            Environment.Exit(0);
        }

        private static void SellSingelTicket()
        {
            var age = Tool<uint>.AskForAnInput("Ålder?", "en ålder");
            //var customerCondition = Sell.FindCustomerCondition(age);
            //var cost = (uint) customerCondition.TicketType;
            var customer= sell.AddCustomer(age);

            var textType = "";

            //switch (customerCondition.AgeType)
            switch (customer.AgeType)
            {
                case AgeType.Centenarian:
                    textType = "Hundraåring";
                    break;
                case AgeType.Pensioner:
                    textType = "Pensionär";
                    break;
                case AgeType.Adult:
                    textType = "Standard";
                    break;
                case AgeType.Young:
                    textType = "Ungdoms";
                    break;
                case AgeType.Child:
                    textType = "Barn";
                    break;
                default:
                    break;
            }
            //Console.WriteLine($"{textType}pris: {cost}");
            Console.WriteLine($"{textType}pris: {sell.TotalCost}");
            sell.RemoveAllCustomers();
        }

        private static void RepeatTextTenTimes()
        {
            var text = Tool<string>.AskForAnInput("Text?", "en text");

            //var i = 1;
            //Console.WriteLine(string.Concat(Enumerable.Repeat(text, 10).Select(t => $"{i}. {t}{(i++ < 10 ? ", " : ".")}")));
            for (int i = 1; i <= 10; i++)
                Console.Write($"{i}. {text}{(i < 10 ? ", " : ".\r\n")}");
        }

        private static void FindTheThirdWord()
        {
            bool success = false;
            do
            {
                var sentence = Tool<string>.AskForAnInput("Skriv upp en mening med minst 3 ord", "en menning med minst 3 ord");
                var subSentence = Regex.Replace(sentence.Trim(), @"\s+", " ").Split(' ');

                if (subSentence.Length >= 3)
                {
                    Console.WriteLine($"Det tredje ordet är \"{subSentence[2]}\"");
                    success = true;
                }

            } while (!success);
        }

        private static void SellGroupTeckets()
        {
            //uint totalCost = 0;
            uint numberOfCustomers = 0;

            numberOfCustomers = Tool<uint>.AskForAnInput("Hur många?", "antal personer");

            for (int i = 0; i < numberOfCustomers; i++)
            {
                var age = Tool<uint>.AskForAnInput("Ålder?", "en ålder");
                sell.AddCustomer(age);
                //var customerCondition = Sell.FindCustomerCondition(age);
                //totalCost += (uint)customerCondition.TicketType;
            }

            //Console.WriteLine($"Antal personer: {numberOfCustomers}");
            Console.WriteLine($"Antal personer: {sell.NumberOfCustomers}");
            Console.WriteLine($"Totalkostnad: {sell.TotalCost}");

            sell.RemoveAllCustomers();
        }

        private static void WrongInput()
        {
            Console.WriteLine("Det är felaktig input");
        }

    }
}
