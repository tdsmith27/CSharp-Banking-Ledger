using System;
using Xunit;
using bankingLedger;

namespace bankingLedgerTests
{
    public class SecurityTests
    {
        [Theory]
        [InlineData("password")]
        [InlineData("p4ssw0rd")]
        [InlineData("ch@4&ct9rs")]
        [InlineData("123456789")]
        public void ValidateHash_Should_Validate_Matching_Password_With_Salt_Theory(string password)
        {            
            string salt = Salt.Create();
            string hash = Hash.Create(password, salt);

            bool match = Hash.Authenticate(password, salt, hash);

            Assert.True(match);
        }

        [Fact]
        public void ValidateHash_Should_Not_Validate_Different_Passwords_With_Same_Salt()
        {
            string password1 = "password";
            string password2 = "password2";
            string salt = Salt.Create();

            string hash = Hash.Create(password1, salt);

            bool match = Hash.Authenticate(password2, salt, hash);

            Assert.False(match);
        }

        [Fact]
        public void ValidateHash_Should_Not_Validate_Same_Password_With_Different_Salt()
        {
            string password = "password";
            string salt1 = Salt.Create();
            string hash = Hash.Create(password, salt1);

            string salt2 = Salt.Create();
            bool match = Hash.Authenticate(password, salt2, hash);

            Assert.False(match);
        }
    }
}
