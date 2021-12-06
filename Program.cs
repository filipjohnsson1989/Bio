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
            var customer = sell.AddCustomer(age);

            //Console.WriteLine($"{customerCondition.ToString()}pris: {cost}");
            Console.WriteLine($"{customer.ToString()}pris: {sell.TotalCost}");
            sell.RemoveAllCustomers();
        }

        private static void RepeatTextTenTimes()
        {
            var text = Tool<string>.AskForAnInput("Text?", "en text");

            Console.Write(TextManagment.RepeatTextTenTimes(text));
        }

        private static void FindTheThirdWord()
        {
            bool success = false;
            do
            {
                var sentence = Tool<string>.AskForAnInput("Skriv upp en mening med minst 3 ord", "en mening med minst 3 ord");
                var theThirdWord = TextManagment.FindTheThirdWord(sentence);

                if (!string.IsNullOrEmpty(theThirdWord))
                {
                    Console.WriteLine($"Det tredje ordet är \"{theThirdWord}\"");
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
