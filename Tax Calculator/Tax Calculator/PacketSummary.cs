using System;
using System.Collections.Generic;
using System.Text;
using Tax_Calculator.Helpers;
using Tax_Calculator.Enums;

namespace Tax_Calculator
{
    public class PacketSummary : IPacketSummary
    {
        private decimal grossSalary = 0.0m;
        private EPayFrequency payFrequency = EPayFrequency.Monthly;

        public PacketSummary(){ }

        #region Setters
        public bool SetGrossSalary(string rawInput)
        {
            if (decimal.TryParse(rawInput, out decimal tempDeci))
            {
                this.grossSalary = tempDeci;
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool SetPayFrequency(string rawInput)
        {
            try
            {
                this.payFrequency = ValidateAsEPayFrequency(rawInput);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Human Readable Values
        public string GetReadableSuperContribution()
        {
            return this.GetSuperContribution().ToString(NumberFormats.CURRENCY_FORMAT);
        }

        public string GetReadableTaxableIncome()
        {
            return this.GetTaxableIncome().ToString(NumberFormats.CURRENCY_FORMAT);
        }

        public string GetReadableGrossSalary()
        {
            return this.GetGrossSalary().ToString(NumberFormats.GROSS_FORMAT);
        }
        
        public string GetReadableNetIncome()
        {
            return this.GetNetIncome().ToString(NumberFormats.CURRENCY_FORMAT);
        }
        
        public string GetReadableDeductions()
        {
            decimal taxableIncome = this.GetTaxableIncome();
            decimal medicareLevy = DeductionCalculator.MedicareLevyAmount(taxableIncome);
            decimal budgetRepairLevy = DeductionCalculator.BudgetRepairLevyAmount(taxableIncome);
            decimal incomeTax = DeductionCalculator.IncomeTax(taxableIncome);
            return (
                $"   Medicare Levy: {medicareLevy.ToString(NumberFormats.CURRENCY_FORMAT)}" +
                $"\n   Budget Repair Levy: {budgetRepairLevy.ToString(NumberFormats.CURRENCY_FORMAT)}" +
                $"\n   Income Tax: {incomeTax.ToString(NumberFormats.CURRENCY_FORMAT)}"
            );
        }
        
        public string GetReadablePayPerInterval()
        {
            int divideBy;
            string perInterval;
            switch (this.GetPayfrequency())
            {
                case EPayFrequency.Weekly:
                    divideBy = CalendarHelper.WEEKS_PER_YEAR;
                    perInterval = "per week";
                    break;
                case EPayFrequency.Fortnightly:
                    divideBy = CalendarHelper.FORTNIGHTS_PER_YEAR;
                    perInterval = "per fortnight";
                    break;
                case EPayFrequency.Monthly:
                    divideBy = CalendarHelper.MONTHS_PER_YEAR;
                    perInterval = "per month";
                    break;
                default:
                    throw new Exception("Switch Statement failed, something went wrong!");
            }

            return $"{Math.Round(this.GetNetIncome() / divideBy, 2, MidpointRounding.AwayFromZero).ToString(NumberFormats.CURRENCY_FORMAT)} {perInterval}";
        }
        #endregion

        #region Private Getters
        private decimal GetGrossSalary()
        {
            return this.grossSalary;
        }

        private EPayFrequency GetPayfrequency()
        {
            return this.payFrequency;
        }
        private decimal GetSuperContribution()
        {
            return Math.Round((this.grossSalary / (1 + 0.095m) * 0.095m), 2);
        }
        private decimal TotalDeductions()
        {
            decimal taxableIncome = this.GetTaxableIncome();
            return DeductionCalculator.MedicareLevyAmount(taxableIncome) + DeductionCalculator.BudgetRepairLevyAmount(taxableIncome) + DeductionCalculator.IncomeTax(taxableIncome);
        }
        private decimal GetTaxableIncome()
        {
            return this.GetGrossSalary() - this.GetSuperContribution();
        }

        private decimal GetNetIncome()
        {
            return this.GetGrossSalary() - this.GetSuperContribution() - this.TotalDeductions();
        }

        private EPayFrequency ValidateAsEPayFrequency(string inputToConvert)
        {
            string loweredInput = inputToConvert.ToLowerInvariant();

            if (loweredInput.IndexOf("w") > -1)
            {
                return EPayFrequency.Weekly;
            }

            if (loweredInput.IndexOf("f") > -1)
            {
                return EPayFrequency.Fortnightly;
            }

            if (loweredInput.IndexOf("m") > -1)
            {
                return EPayFrequency.Monthly;
            }

            throw new Exception("Invalid Frequency");
        }
        #endregion
    }
}
