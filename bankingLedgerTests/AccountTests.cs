using System;
using Xunit;
using bankingLedger;

namespace bankingLedgerTests
{
    public class AccountTests
    {
        Account account;

        public AccountTests()
        {
            account = new Account("trevor", "password");
        }

        [Fact]
        public void CheckBalance_Should_Match_Deposits()
        {
            account.Deposit(100);
            Assert.Equal(100, account.CheckBalance());
        }

        [Fact]
        public void CheckBalance_Should_Match_Deposits_Minus_Withdrawals()
        {
            account.Deposit(100);
            account.Deposit(100);
            account.Withdraw(50);
            Assert.Equal(150, account.CheckBalance());
        }

        [Fact]
        public void Invalid_Withdrawal_Should_Throw_Exception()
        {            
            Exception e = Assert.Throws<Exception>(() => account.Withdraw(100));

            Assert.Equal("Not enough funds", e.Message);
        }

        [Fact]
        public void TransactionLog_Should_Include_All_Transactions()
        {
            account.Deposit(100);
            account.Deposit(100);
            account.Withdraw(100);

            Assert.Equal(3, account.transactionLog.Count);
        }

        [Fact]
        public void AuthenticatePassword_Should_Authenticate_Valid_Password()
        {
            Exception e = Record.Exception(() => account.AuthenticatePassword("password"));

            Assert.Null(e);
        }

        [Fact]
        public void AuthenticatePassword_Should_Not_Authenticate_Invalid_Password()
        {
            Exception e = Assert.Throws<Exception>(() => account.AuthenticatePassword("wrong"));

            Assert.Equal("Password does not match", e.Message);
        }
    }    
}
