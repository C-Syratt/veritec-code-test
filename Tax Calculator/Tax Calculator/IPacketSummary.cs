using System;
using System.Collections.Generic;
using System.Text;

namespace Tax_Calculator
{
    interface IPacketSummary
    {
        string GetReadableGrossSalary();
        string GetReadableSuperContribution();
        string GetReadableTaxIncome();
        string GetReadableDeductions();
        string GetReadableNetIncome();
        string GetReadablePayPerInterval();
    }
}
