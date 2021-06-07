using System;
using System.Collections.Generic;
using System.Text;

namespace Tax_Calculator.Configuration
{
    public static class TaxBrackets
    {
        public static decimal FirstBracketMin = 18200;
        public static decimal FirstBracketMax = 37000;
        public static decimal FirstBracketFlat = 0;

        public static decimal SecondBracketMin = 37001;
        public static decimal SecondBracketMax = 87000;
        public static decimal SecondBracketFlat = 3572;

        public static decimal ThirdBracketMin = 87001;
        public static decimal ThirdBracketMax = 180000;
        public static decimal ThirdBracketFlat = 19822;

        // Flat for greater than third bracket max
        public static decimal AndOverFlat = 54232;
    }
}
