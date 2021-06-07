using System;
using System.Collections.Generic;
using System.Text;

namespace Tax_Calculator.Helpers
{
    public static class DeductionCalculator
    {
        public static decimal MedicareLevyAmount(decimal taxable)
        {
            if(IsBetween(taxable, 21336, 26668))
            {
                return Math.Ceiling((taxable - 21336) * 0.1m);
            }
            else if(taxable >= 2669)
            {
                return Math.Ceiling(taxable * 0.02m);
            }
            else
            {
                return 0;
            }
        }

        public static decimal BudgetRepairLevyAmount(decimal taxbable)
        {
            if(taxbable >= 180001)
            {
                return Math.Ceiling((taxbable - 180001) * 0.02m);
            }
            else
            {
                return 0;
            }
        }

        public static decimal IncomeTax(decimal taxable)
        {
            if(IsBetween(taxable, 18201, 37000))
            {
                return Math.Ceiling((taxable - 18201) * 0.19m);
            }
            else if(IsBetween(taxable, 37001, 87000))
            {
                return Math.Ceiling(((taxable - 37001) * 0.325m) + 3572);
            }
            else if(IsBetween(taxable, 87001, 180000))
            {
                return Math.Ceiling(((taxable - 87001) * 0.37m) + 19822);
            }
            else if (taxable >= 180001)
            {
                return Math.Ceiling(((taxable - 180001) * 0.47m) + 54232);
            }
            else
            {
                return 0;
            }
        }

        private static bool IsBetween(decimal value, decimal min, decimal max)
        {
            return (value >= min && value <= max);
        }
    }
}
