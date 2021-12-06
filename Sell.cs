using Bio.Entities;
using Bio.Structs;
using Bio.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bio
{
    class Sell
    {
        private List<Customer> customers;

        private static CustomerCondition[] customerConditions;
        private static uint customerConditionIndex = 0;

        private int numberOfCustomers = 0;
        private int totalCost = 0;

        public int NumberOfCustomers { get { return numberOfCustomers; } }
        public int TotalCost { get { return totalCost; } }

        public Sell()
        {
            customers = new List<Customer>();
            //customerConditions = new CustomerCondition[5];
            //SeedData();
        }

        private static void SeedData()
        {
            AddCustomerCondition(ageType: AgeType.Centenarian, ticketType: TicketType.Free);
            AddCustomerCondition(ageType: AgeType.Pensioner, ticketType: TicketType.Pensioner);
            AddCustomerCondition(ageType: AgeType.Adult, ticketType: TicketType.Adult);
            AddCustomerCondition(ageType: AgeType.Young, ticketType: TicketType.Young);
            AddCustomerCondition(ageType: AgeType.Child, ticketType: TicketType.Free);
        }

        private static void AddCustomerCondition(AgeType ageType, TicketType ticketType)
        {
            customerConditions[customerConditionIndex].AgeType = ageType;
            customerConditions[customerConditionIndex].TicketType = ticketType;
            customerConditionIndex++;
        }

        public static CustomerCondition FindCustomerCondition(uint age)
        {
            foreach (var customerCondition in customerConditions.Take(customerConditions.Length - 1))
            {
                if (age >= (uint)customerCondition.AgeType) return customerCondition;
            }

            return customerConditions.LastOrDefault();
        }


        private TicketType FindTicketType(Customer customer)
        {
            TicketType result = TicketType.Free;
            switch (customer.AgeType)
            {
                case AgeType.Pensioner:
                    result = TicketType.Pensioner;
                    break;

                case AgeType.Adult:
                    result = TicketType.Adult;
                    break;

                case AgeType.Young:
                    result = TicketType.Young;
                    break;
            }

            return result;
        }

        public Customer AddCustomer(uint age)
        {
            Customer customer = new Customer(age: age);
            customers.Add(customer);
            this.numberOfCustomers++;
            this.totalCost += (int)FindTicketType(customer);
            return customer;
        }

        public void RemoveAllCustomers()
        {
            customers = new List<Customer>();
            numberOfCustomers = 0;
            totalCost = 0;
            GC.Collect();
        }
    }
}
