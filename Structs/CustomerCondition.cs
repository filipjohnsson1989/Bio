using Bio.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bio.Structs
{
    //struct CustomerCondition : IComparable
    struct CustomerCondition
    {
        public AgeType AgeType;
        public TicketType TicketType;

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
