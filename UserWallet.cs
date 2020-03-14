using System.Collections.Generic;

namespace CreditCardInterestPerUser.Model
{
    public class UserWallet
    {
        public List<CreditCard> CreditCards { get; set; }

        public double InterestOnWallet { get; set; }
    }

}
