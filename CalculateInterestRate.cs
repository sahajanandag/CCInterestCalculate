using CreditCardInterestPerUser.Model;
using NUnit.Framework;
using System.Collections.Generic;

namespace CreditCardInterestPerUser
{
    [TestFixture]
    public class CalculateInterestUnitTest
    {
        public CreditCard VisaCard;
        public CreditCard MasterCard;
        public CreditCard DiscoverCard;

        [SetUp]
        public void TestInitialize()
        {
            VisaCard = new CreditCard
            {
                CreditCardType = CreditCard.TypeOfCreditCard.VISA,
                CreditInterestRate = 10,
                CreditBalance = 100
            };

            MasterCard = new CreditCard
            {
                CreditCardType = CreditCard.TypeOfCreditCard.MASTERCARD,
                CreditInterestRate = 5,
                CreditBalance = 100
            };

            DiscoverCard = new CreditCard
            {
                CreditCardType = CreditCard.TypeOfCreditCard.DISCOVER,
                CreditInterestRate = 1,
                CreditBalance = 100
            };
        }

        /// <summary>
        /// 1 user has 1 wallet and 3 cards (1 Visa, 1 MasterCard, 1 Discover) – Each Card has a balance of $100
        /// Calculate the total interest for this user and per card
        /// </summary>
        [Test]
        public void InterestTestCase1()
        {
            // arrange
            var userWallet1 = new UserWallet
            {
                CreditCards = new List<CreditCard>
                {
                    VisaCard,
                    MasterCard,
                    DiscoverCard
                }
            };

            var user1 = new User
            {
                UserWallets = new List<UserWallet>
                {
                    userWallet1
                }
            };

            //act
            var TotalInterest = user1.CalculateTotalInterest();

            //assert
            Assert.AreEqual(TotalInterest, 16);
        }

        /// <summary>
        /// 1 user has 2 wallets Wallet 1 has a Visa and Discover , wallet 2 a MasterCard - each card has $100 balance
        /// Calculate the total interest for this user and interest per wallet
        /// </summary>
        [Test]
        public void InterestTestCase2()
        {
            // arrange
            var userWallet1 = new UserWallet
            {
                CreditCards = new List<CreditCard>
                {
                    VisaCard,
                    DiscoverCard
                }
            };

            var userWallet2 = new UserWallet
            {
                CreditCards = new List<CreditCard>
                {
                    MasterCard
                }
            };

            var user1 = new User
            {
                UserWallets = new List<UserWallet>
                {
                    userWallet1,
                    userWallet2
                }
            };

            //act
            var TotalInterest = user1.CalculateTotalInterest();

            //assert
            Assert.AreEqual(TotalInterest, 16);
            Assert.AreEqual(user1.UserWallets[0].InterestOnWallet, 11);
            Assert.AreEqual(user1.UserWallets[1].InterestOnWallet, 5);
        }

        /// <summary>
        /// 2 people have 1 wallet each,
        /// user 1 has 1 wallet with 3 cards (1 MasterCard, 1 VisaCard, 1 DiscoverCard),
        /// user 2 has 1 wallet with 2 cards (1 VisaCard, 1 MasterCard) all cards in all wallets for both people have a $100 balance
        /// Calculate the total interest for each user and interest per wallet
        /// </summary>
        [Test]
        public void InterestTestCase3()
        {
            var userWallet1 = new UserWallet
            {
                CreditCards = new List<CreditCard>
                {
                    MasterCard,
                    VisaCard,
                    DiscoverCard
                }
            };

            var user1 = new User
            {
                UserWallets = new List<UserWallet>
                {
                    userWallet1
                }
            };

            var userWallet2 = new UserWallet
            {
                CreditCards = new List<CreditCard>
                {
                    VisaCard,
                    MasterCard
                }
            };

            var user2 = new User
            {
                UserWallets = new List<UserWallet>
                {
                    userWallet2
                }
            };


            //act
            var TotalInterestA = user1.CalculateTotalInterest();
            var TotalInterestB = user2.CalculateTotalInterest();

            //assert
            Assert.AreEqual(TotalInterestA, 16);
            Assert.AreEqual(TotalInterestB, 15);
            Assert.AreEqual(user1.UserWallets[0].InterestOnWallet, 16);
            Assert.AreEqual(user2.UserWallets[0].InterestOnWallet, 15);
        }
    }
}


