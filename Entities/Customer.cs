using Bio.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bio.Entities
{
    //Det finns en annan kod för samma logik i den Sell klassen som är implementeras med CustomerConditions klass
    class Customer
    {
        //Fält
        private uint age;
        
        //Properties
        public AgeType AgeType { get; }


        //Konstruktor
        public Customer(uint age)
        {
            this.age = age;
            this.AgeType = FindAgeType();
        }

        //Metoder
        //Här finner vi att kunden tillhör vilken grupp utifrån ålder.
        //vi börjar kolla från den äldsta gruppen eftersom det inte finns någon maxålder för denna grupp.
        //Vi stannar till med att kolla barnets grupp. Det går inte att vara yngre än noll år.
        //1 dag gammal till 11 månader gammal innebär 0 år
        //Det finns en annan kod för samma logik i den Sell klassen som är FindCustomerCondition och den implementeras utan att använda kundklass. Den koden används om vi bestämmer oss för att ge användare tillåtelse att ändra intervallet för åldersgrupperna i framtiden. Det har gjorts för mer övning.
        public AgeType FindAgeType()
        {
            if (this.age >= (uint)AgeType.Young)
            {
                if (this.age >= (uint)AgeType.Adult)
                {
                    if (this.age >= (uint)AgeType.Pensioner)
                    {
                        if (this.age >= (uint)AgeType.Centenarian)
                        {
                            return AgeType.Centenarian;
                        }
                        return AgeType.Pensioner;
                    }
                    return AgeType.Adult;
                }
                return AgeType.Young;
            }

            return (uint)AgeType.Child;

        }

        //Vi specialiserar betendet av ToString() metoden. Istället för default implementationen så vill vi att den här koden körs när vi anropar .ToString() på en Customer instans.
        public override string ToString()
        {
            string textType=string.Empty;

            switch (this.AgeType)
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
            return textType;
        }

    }
}
