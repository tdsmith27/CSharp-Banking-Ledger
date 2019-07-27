using System;
using Xunit;
using bankingLedger;

namespace bankingLedgerTests
{
    public class ValidateTests
    {

        // Transaction validation

        [Fact]
        public void Transaction_Should_Validate_Valid_Input_1()
        {
            Exception e = Record.Exception(() => Validate.Transaction("100"));

            Assert.Null(e);
        }

        [Fact]
        public void Transaction_Should_Validate_Valid_Input_2()
        {
            Exception e = Record.Exception(() => Validate.Transaction("100.00"));

            Assert.Null(e);
        }

        [Fact]
        public void Transaction_Should_Validate_Valid_Input_3()
        {
            Exception e = Record.Exception(() => Validate.Transaction("100.6"));

            Assert.Null(e);
        }

        [Fact]
        public void Transaction_Should_Validate_Valid_Input_4()
        {
            Exception e = Record.Exception(() => Validate.Transaction("100."));

            Assert.Null(e);
        }

        [Fact]
        public void Transaction_Should_Not_Validate_Negative_Input()
        {
            Exception e = Assert.Throws<Exception>(() => Validate.Transaction("-100"));

            Assert.Equal("Transaction amount must be a positive number with up to 2 decimal places", e.Message);
        }

        [Fact]
        public void Transaction_Should_Not_Validate_Input_With_3_Decimals()
        {
            Exception e = Assert.Throws<Exception>(() => Validate.Transaction("100.504"));

            Assert.Equal("Transaction amount must be a positive number with up to 2 decimal places", e.Message);
        }

        [Fact]
        public void Transaction_Should_Not_Validate_Text_Input()
        {
            Exception e = Assert.Throws<Exception>(() => Validate.Transaction("One hundred dollars"));

            Assert.Equal("Transaction amount must be a positive number with up to 2 decimal places", e.Message);
        }


        // Password validation

        [Fact]
        public void Password_Should_Validate_Valid_Input_1()
        {
            Exception e = Record.Exception(() => Validate.Password("abcdef"));

            Assert.Null(e);
        }

        [Fact]
        public void Password_Should_Validate_Valid_Input_2()
        {
            Exception e = Record.Exception(() => Validate.Password("abc123"));

            Assert.Null(e);
        }

        [Fact]
        public void Password_Should_Not_Validate_Input_With_Whitespace()
        {
            Exception e = Assert.Throws<Exception>(() => Validate.Password("wrong pass"));

            Assert.Equal("Password must be at least 6 characters long with no whitespaces", e.Message);
        }

        [Fact]
        public void Password_Should_Not_Validate_Short_Input()
        {
            Exception e = Assert.Throws<Exception>(() => Validate.Password("wrong"));

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
