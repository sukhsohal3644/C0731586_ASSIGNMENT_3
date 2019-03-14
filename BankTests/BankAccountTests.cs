using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

// Name : Sukhdeep Sohal         Student ID : c0731586
// Name : Ankita Sharma          Student ID : c0730066
// Course : CSD3354_1 
namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            //ACT
            account.Debit(debitAmount);

            //Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_shouldThrowArgumentOutOfRange()
        {
            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            //Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                //assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown");
        }
        [TestMethod]
        public void Debit_WhenAmountisMoreThanBalance_shouldThrowArgumentOutOfRange()
        {
            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            //act
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                //Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown");
        }
    }
}