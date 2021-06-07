using System;
using System.Collections.Generic;
using System.Text;
using Tax_Calculator.Configuration;

namespace Tax_Calculator.Helpers
{
    public static class DeductionCalculator
    {
        public static decimal MedicareLevyAmount(decimal taxable)
        {
            if(IsBetween(taxable, MedicareBrackets.FirstBracketMin, MedicareBrackets.FirstBracketMax))
            {
                return Math.Ceiling( AmountOver(taxable, MedicareBrackets.FirstBracketMin) * 0.1m );
            }
            else if(taxable >= MedicareBrackets.FirstBracketMax + 1)
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
            if(taxbable >= BudgetRepairBrackets.LevyThreshold + 1)
            {
                return Math.Ceiling( AmountOver(taxbable, BudgetRepairBrackets.LevyThreshold) * 0.02m );
            }
            else
            {
                return 0;
            }
        }

        public static decimal IncomeTax(decimal taxable)
        {
            if(IsBetween(taxable, TaxBrackets.FirstBracketMin, TaxBrackets.FirstBracketMax))
            {
                return Math.Ceiling( AmountOver(taxable, TaxBrackets.FirstBracketMin + 1) * 0.19m );
            }
            else if(IsBetween(taxable, TaxBrackets.SecondBracketMin, TaxBrackets.SecondBracketMax))
            {
                return Math.Ceiling( (AmountOver(taxable, TaxBrackets.SecondBracketMin + 1) * 0.325m) + TaxBrackets.SecondBracketFlat );
            }
            else if(IsBetween(taxable, TaxBrackets.ThirdBracketMin, TaxBrackets.ThirdBracketMax))
            {
                return Math.Ceiling( (AmountOver(taxable, TaxBrackets.ThirdBracketMin + 1) * 0.37m) + TaxBrackets.ThirdBracketFlat);
            }
            else if (taxable >= TaxBrackets.ThirdBracketMax + 1)
            {
                return Math.Ceiling( (AmountOver(taxable, TaxBrackets.ThirdBracketMax + 1) * 0.47m) + TaxBrackets.AndOverFlat );
            }
            else
            {
                return 0;
            }
        }

        private static decimal AmountOver(decimal value, decimal over)
        {
            return value - over;
        }

        private static bool IsBetween(decimal value, decimal min, decimal max)
        {
            return (value >= min && value <= max);
        }
    }
}
