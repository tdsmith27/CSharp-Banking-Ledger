using System;
using Xunit;
using bankingLedger;

namespace bankingLedgerTests
{
    public class ValidateTests
    {

        // Valid Transaction Inputs

        [Theory]
        [InlineData("100")]
        [InlineData("100.00")]
        [InlineData("100.6")]
        [InlineData("100.")]
        [InlineData("0")]
        public void Transaction_Should_Validate_Valid_Input_Theory(string transaction)
        {
            Exception e = Record.Exception(() => Validate.Transaction(transaction));

            Assert.Null(e);
        }                

        // Invalid Transaction Inputs

        [Theory]
        [InlineData("-100")]
        [InlineData("-100.504")]
        [InlineData("one hundred dollars")]
        public void Transaction_Should_Not_Validate_Invalid_Inputs_Theory(string transaction)
        {
            Exception e = Assert.Throws<Exception>(() => Validate.Transaction(transaction));

            Assert.Equal("Transaction amount must be a positive number with up to 2 decimal places", e.Message);
        }

        // Valid Password Inputs

        [Theory]
        [InlineData("abcdef")]
        [InlineData("abc123")]
        public void Password_Should_Validate_Valid_Inputs_Theory(string password)
        {
            Exception e = Record.Exception(() => Validate.Password(password));

            Assert.Null(e);
        }

        // Invalid Password Inputs

        [Theory]
        [InlineData("no whitespace")]
        [InlineData("short")]
        public void Password_Should_Not_Validate_Invalid_Inputs_Theory(string password)
        {
            Exception e = Assert.Throws<Exception>(() => Validate.Password(password));

            Assert.Equal("Password must be at least 6 characters long with no whitespaces", e.Message);
        }

        // New Username validation

        [Fact]
        public void NewUsername_Should_Validate_New_Username()
        {
            Exception e = Record.Exception(() => Validate.NewUsername("Trevor"));

            Assert.Null(e);
        }        

        [Fact]
        public void NewUsername_Should_Not_Validate_Existing_Username()
        {
            Account account = new Account("trevor", "password");
            Program.accounts.Add(account);

            Exception e = Record.Exception(() => Validate.NewUsername("trevor"));
            Assert.Equal("That username already exists - would you like to log in?", e.Message);
        }
    }
}
