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

        private static void GetUserInput()
        {
            var input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    ClosePrograme();
                    break;
                case "1":
                    SellSingelTicket();
                    break;
                case "2":
                    RepeatTextTenTimes();
                    break;
                case "3":
                    FindTheThirdWord();
                    break;
                case "4":
                    SellGroupTeckets();
                    break;
                default:
                    WrongInput();
                    break;
            }
        }

        private static void WrongInput()
        {
            Console.WriteLine("Det är felaktig input");
        }

        private static void SellGroupTeckets()
        {
            uint totalCost = 0;
            uint numberOfCustomers = 0;

            Console.WriteLine("Hur många?");
            numberOfCustomers = uint.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCustomers; i++)
            {
                Console.WriteLine("Åldrar?");
                totalCost += FindCustomerCondition(uint.Parse(Console.ReadLine())).Price;
            }

            Console.WriteLine($"Antal personer: {numberOfCustomers}");
            Console.WriteLine($"Totalkostnad: {totalCost}");
        }

        private static void FindTheThirdWord()
        {
            Console.WriteLine("Skriv in en mening med minst 3 ord");
            var sentence = Console.ReadLine();
            var subSentence = Regex.Replace(sentence, @"\s+", " ").Split(' ');
            if (subSentence.Length >= 3) Console.WriteLine($"Det tredje ordet är \"{subSentence[2]}\"");
            else Console.WriteLine("Meningen med minst 3 ord!");
        }

        private static void RepeatTextTenTimes()
        {
            Console.WriteLine("Text?");
            var text = Console.ReadLine();

            //var i = 1;
            //Console.WriteLine(string.Concat(Enumerable.Repeat(text, 10).Select(t => $"{i}. {t}{(i++ < 10 ? ", " : ".")}")));
            for (int i = 1; i <= 10; i++)
                Console.Write($"{i}. {text}{(i < 10 ? ", " : ".\r\n")}");
        }

        private static void SellSingelTicket()
        {
            uint cost = 0;

            Console.WriteLine("Ålder?");
            cost = FindCustomerCondition(uint.Parse(Console.ReadLine())).Price;
            Console.WriteLine($"Kostnad: {cost}");
        }

        private static void ClosePrograme()
        {
            Console.WriteLine("Stängs");
            Environment.Exit(0);
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

        private static CustomerCondition FindCustomerCondition(uint age)
        {
            foreach (var customerCondition in customerConditions.Skip(1))
            {
                if (age < customerCondition.MinAge) return customerCondition;
            }

            return customerConditions.FirstOrDefault();
        }

        private static void AddCustomerCondition(CustomerType customerType, uint minAge, uint price)
        {
            customerConditions[(int)customerType].Type = customerType;
            customerConditions[(int)customerType].MinAge = minAge;
            customerConditions[(int)customerType].Price = price;
        }

        private static void SeedData()
        {
            AddCustomerCondition(customerType: CustomerType.Child, minAge: 0, price: 0);
            AddCustomerCondition(customerType: CustomerType.Young, minAge: 5, price: 80);
            AddCustomerCondition(customerType: CustomerType.Adult, minAge: 20, price: 120);
            AddCustomerCondition(customerType: CustomerType.Pensioner, minAge: 65, price: 90);
            AddCustomerCondition(customerType: CustomerType.Centenarian, minAge: 100, price: 0);
        }
    }
}
