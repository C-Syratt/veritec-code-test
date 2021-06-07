using System;
using System.Collections.Generic;
using System.Text;

namespace Tax_Calculator
{
    interface IPacketSummary
    {
        /// <summary>
        /// Sets the gross salary if input is valid
        /// </summary>
        /// <param name="rawInput">input string from user</param>
        /// <returns>true if the input was valid</returns>
        public bool SetGrossSalary(string rawInput);
        
        /// <summary>
        /// Sets the pay frequency if input is valid
        /// </summary>
        /// <param name="rawInput"></param>
        /// <returns>true if the input was valid</returns>
        public bool SetPayFrequency(string rawInput);

        /// <summary> Returns the gross salary as a currency formated string </summary>
        string GetReadableGrossSalary();

        /// <summary> Returns the Superannuation contribution as a currency formated string </summary>
        string GetReadableSuperContribution();

        /// <summary> Returns the taxable income as a currency formated string </summary>
        string GetReadableTaxableIncome();

        /// <summary> Returns the net income as a currency formated string </summary>
        string GetReadableNetIncome();

        /// <summary> Returns a string listing deductions and their formatted amounts </summary>
        string GetReadableDeductions();

        /// <summary> Returns the pay packet amount (formatted) and the frequency (e.g. "$4003.94 per month")</summary>        
        string GetReadablePayPerInterval();
    }
}
