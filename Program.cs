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
        private static uint customerConditionIndex = 0;
        private static CustomerCondition[] customerConditions = new CustomerCondition[5];

        static void Main(string[] args)
        {
            SeedData();
            do
            {
                // Huvudmeny
                ShowMainMenu();
                GetUserInput();
            } while (true);
        }

        private static void SeedData()
        {
            AddCustomerCondition(ageType: AgeType.Centenarian, ticketType: TicketType.Free);
            AddCustomerCondition(ageType: AgeType.Pensioner, ticketType: TicketType.Pensioner);
            AddCustomerCondition(ageType: AgeType.Adult, ticketType: TicketType.Adult);
            AddCustomerCondition(ageType: AgeType.Young, ticketType: TicketType.Young);
            AddCustomerCondition(ageType: AgeType.Child, ticketType: TicketType.Free);
        }

        private static CustomerCondition FindCustomerCondition(uint age)
        {
            foreach (var customerCondition in customerConditions.Take(customerConditions.Length - 1))
            {
                if (age >= (uint) customerCondition.AgeType) return customerCondition;
            }

            return customerConditions.LastOrDefault();
        }

        private static void AddCustomerCondition(AgeType ageType, TicketType ticketType)
        {
            customerConditions[customerConditionIndex].AgeType = ageType;
            customerConditions[customerConditionIndex].TicketType = ticketType;
            customerConditionIndex++;
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
            var customerCondition = FindCustomerCondition(Tool<uint>.AskForAnInput("Ålder?", "en ålder"));
            var cost = (uint) customerCondition.TicketType;
            var textType = "";
            switch (customerCondition.AgeType)
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
            Console.WriteLine($"{textType}pris: {cost}");
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
            uint totalCost = 0;
            uint numberOfCustomers = 0;

            numberOfCustomers = Tool<uint>.AskForAnInput("Hur många?", "antal personer");

            for (int i = 0; i < numberOfCustomers; i++)
            {
                totalCost += (uint) FindCustomerCondition(Tool<uint>.AskForAnInput("Ålder?", "en ålder")).TicketType;
            }

            Console.WriteLine($"Antal personer: {numberOfCustomers}");
            Console.WriteLine($"Totalkostnad: {totalCost}");
        }

        private static void WrongInput()
        {
            Console.WriteLine("Det är felaktig input");
        }

    }
}
