using Bio.Structs;
using Bio.Types;
using System;
using System.Collections.Generic;

namespace Bio
{
    class Program
    {
        private static CustomerCondition[] customerConditions = new CustomerCondition[5];
        static void Main(string[] args)
        {
            SeedData();
            // Huvudmeny
            do
            {
                Console.WriteLine("Huvudmeny");
                Console.WriteLine("0: Stäng av");
                Console.WriteLine("1: Sälja enskild");
                Console.WriteLine("2: Upprepa tio gånger");
                Console.WriteLine("3: Sälja till ett helt sällskap");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Console.WriteLine("Stängs");
                        Environment.Exit(0);
                        break;
                    case "1":
                        uint cost = 0;

                        Console.WriteLine("Ålder?");
                        cost = FindCustomerCondition(uint.Parse(Console.ReadLine())).Price;
                        Console.WriteLine($"Kostnad: {cost}");
                        break;
                    case "2":
                        throw new NotImplementedException();
                        break;
                    case "3":
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
                        break;
                    default:
                        Console.WriteLine("Det är felaktig input");
                        break;
                }
            } while (true);

        }

        private static void SeedData()
        {
            AddCustomerCondition(customerType: CustomerType.Child, minAge: 0, price: 0);
            AddCustomerCondition(customerType: CustomerType.Young, minAge: 5, price: 80);
            AddCustomerCondition(customerType: CustomerType.Adult, minAge: 20, price: 120);
            AddCustomerCondition(customerType: CustomerType.Pensioner, minAge: 65, price: 90);
            AddCustomerCondition(customerType: CustomerType.Centenarian, minAge: 100, price: 0);
        }

        private static void AddCustomerCondition(CustomerType customerType, uint minAge, uint price)
        {
            customerConditions[(int)customerType].Type = customerType;
            customerConditions[(int)customerType].MinAge = minAge;
            customerConditions[(int)customerType].Price = price;
        }


        private static CustomerCondition FindCustomerCondition(uint age)
        {
            var minCustomerType = CustomerType.Child;

            for (CustomerType customerType = CustomerType.Centenarian; customerType >= minCustomerType; customerType--)
            {
                CustomerCondition customerCondition = customerConditions[(int)customerType];
                if (age >= customerConditions[(int)customerType].MinAge) return customerConditions[(int)customerType];
            }

            return customerConditions[(int)minCustomerType];
        }
    }
}
