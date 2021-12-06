using Bio.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bio.Entities
{
    class Customer
    {
        private uint age;
        public AgeType AgeType { get; }

        public Customer(uint age)
        {
            this.age = age;
            this.AgeType = FindAgeType();
        }

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
        
    }
}
