using System.Collections.Generic;

namespace CreditCardInterestPerUser.Model
{
    public class User
    {
        public List<UserWallet> UserWallets { get; set; }

        public double CalculateTotalInterest()
        {
            double totalInterest = 0.0;

            foreach (var wallet in UserWallets)
            {
                foreach (var creditCard in wallet.CreditCards)
                {
                    creditCard.CreditInterest = (creditCard.CreditInterestRate * creditCard.CreditBalance) / 100;

                    wallet.InterestOnWallet += creditCard.CreditInterest;
                    totalInterest += creditCard.CreditInterest;
                }
            }

            return totalInterest;
        }
    }
}
