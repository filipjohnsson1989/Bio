using Bio.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bio.Structs
{
    //För mer övning om struct och ha en redo kod i framtiden.
    //Den har är kommenterats eftersom den inte har använts.
    //struct CustomerCondition : IComparable
    struct CustomerCondition
    {
        public AgeType AgeType;
        public TicketType TicketType;

        //För mer övning och ha en redo kod i framtiden.
        //Den har är kommenterats eftersom den inte har använts.
        //public int CompareTo(object obj)
        //{
        //    var otherCustomerCondition = (CustomerCondition)obj;
        //    if (MinAge > otherCustomerCondition.MinAge)
        //        return 1;
        //    else if (MinAge < otherCustomerCondition.MinAge)
        //        return -1;
        //    else
        //        return 0;
        //}


        //Vi specialiserar betendet av ToString() metoden. Istället för default implementationen så vill vi att den här koden körs när vi anropar .ToString() på en Customer instans.
        //Det finns en annan kod för samma logik i den Sell klassen
        public override string ToString()
        {
            string textType = string.Empty;

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
            }
            return textType;
        }
    }
}
