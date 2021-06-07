using System;

namespace Tax_Calculator
{
    class Program
    {
        private static PacketSummary CurrentPacket;

        static void Main()
        {
            InitializePacket();
            EnterGrossIncomeAndFrequency();
            AssemblePayPacket();
            ProgramComplete();
        }

        private static void InitializePacket()
        {
            Console.WriteLine("Initialising...");
            CurrentPacket = new PacketSummary();
        }

        /// <summary>
        /// Handle the collection and validation of the user inputs for Salary and Pay Frequency
        /// </summary>
        private static void EnterGrossIncomeAndFrequency()
        {
            const string FREQUENCY_LEGEND = "\nw = Weekly;\nf = Fortnightly;\nm = Monthly;";
            try
            {
                Console.WriteLine("Hello, please provide your salary as a valid decimal amount\n");
                
                // Retry until a valid input is given
                while (CurrentPacket.SetGrossSalary(Console.ReadLine()) == false)
                {
                    Console.WriteLine("\nInvalid Number! I need what you enter to be a valid number please.\n Enter a valid decimal number:");
                }
                
                Console.WriteLine($"\nExcellent! Are you paid Weekly, Fortnightly, or Monthly?{FREQUENCY_LEGEND}\n");
                // As above; Retry until a valid input is given
                while (CurrentPacket.SetPayFrequency(Console.ReadLine()) == false)
                {
                    Console.WriteLine($"\nInvalid Frequency! Sorry, but I don't recognise what you entered.\n Please use the following for recognised inputs:{FREQUENCY_LEGEND}\n");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Assemble the breakdown values and display them nicely
        /// </summary>
        private static void AssemblePayPacket()
        {
            Console.WriteLine("\nBrilliant, now give me just a moment to calculate your pay packet breakdown...");

            Console.WriteLine(
                $"\n Gross Package: {CurrentPacket.GetReadableGrossSalary()}" +
                $"\n Superannuation: {CurrentPacket.GetReadableSuperContribution()}" +
                $"\n\n Taxable Income: {CurrentPacket.GetReadableTaxableIncome()}" +
                $"\n\n Deductions: \n{CurrentPacket.GetReadableDeductions()}" +
                $"\n\n Net income: {CurrentPacket.GetReadableNetIncome()}" +
                $"\n Pay Packet: {CurrentPacket.GetReadablePayPerInterval()}"
            );
        }

        /// <summary>
        /// Any key to exit
        /// </summary>
        private static void ProgramComplete()
        {
            Console.Write("\n\nI hope this helped out! We're all finished here, when you're ready press any key to close...");
            Console.ReadKey();
        }

    }
}
