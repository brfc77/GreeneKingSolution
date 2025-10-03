namespace GreeneKingSpeaker.Calculators
{
    public class FeeCalculator : IFeeCalculator
    {
        /* This replaces this set of IF statements 
         * if (Exp <= 1)
            {
                RegistrationFee = 500;
            }
            else if (Exp >= 2 && Exp <= 3)
            {
                RegistrationFee = 250;
            }
            else if (Exp >= 4 && Exp <= 5)
            {
                RegistrationFee = 100;
            }
            else if (Exp >= 6 && Exp <= 9)
            {
                RegistrationFee = 50;
            }
            else
            {
                RegistrationFee = 0;
            }
        */
        public int CalculateFee(int? experienceYears)
        {
            return experienceYears switch
            {
                <= 1 => 500,
                <= 3 => 250,
                <= 5 => 100,
                <= 9 => 50,
                _ => 0
            };
        }
    }
}
