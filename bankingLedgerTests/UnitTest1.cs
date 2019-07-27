using System;
using Xunit;
using bankingLedger;

namespace bankingLedgerTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var account = new Account("trevor", "password");
            account.Deposit(100);
            Assert.Equal(100, account.CheckBalance());
        }
    }
}
