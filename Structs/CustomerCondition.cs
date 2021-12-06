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
        public uint Price;

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
    }
}
