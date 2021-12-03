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
                Console.WriteLine("1: Ungdom eller pensionär");
                Console.WriteLine("2: Upprepa tio gånger");
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
            var customerCondition = customerConditions[(int)customerType];
            customerCondition.Type = customerType;
            customerCondition.MinAge = minAge;
            customerCondition.Price = price;
        }


    }
}
