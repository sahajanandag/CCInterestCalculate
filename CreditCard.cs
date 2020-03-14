namespace CreditCardInterestPerUser.Model
{
    public class CreditCard
    {
        public enum TypeOfCreditCard
        {
            VISA,
            MASTERCARD,
            DISCOVER
        }

        public TypeOfCreditCard CreditCardType { get; set; }

        public double CreditInterestRate { get; set; }

        public double CreditBalance { get; set; }

        public double CreditInterest { get; set; }
    }
}
