using CashBillInAction.Currency;
using System;
using System.Collections.Generic;
using Xunit;

namespace CashBillInAction.tests.Currency
{
    /// <summary>
    /// Test Class.
    /// </summary>
    public class USCurrencyTests
    {
        #region Tests

        #region GetInteger

        /// <summary>
        /// Numbers are provided, integer part of number is returned.
        /// </summary>
        /// <param name="numbers">Integer part of numbers.</param>
        [Trait("Category", "Unit")]
        [Theory]
        [MemberData(nameof(ModesDataForInteger))]
        public void GetInteger_NumbersAreProvided_NumbersInWordIsReturned(KeyValuePair<int, string> numbers)
        {
            // Arrange 
            var uSCurrency = new USCurrency();

            // Act 
            var actual = uSCurrency.GetInteger(numbers.Key);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(numbers.Value, actual);
        }

        /// <summary>
        /// Negative number is provided, Exception is thrown.
        /// </summary>
        [Trait("Category", "Unit")]
        [Fact]
        public void GetInteger_NegativeNumberIsProvided_ExceptionIsThrown()
        {
            // Arrange 
            var uSCurrency = new USCurrency();

            // Act 
            // Assert
            Assert.Throws<Exception>(() => uSCurrency.GetInteger(-3));
        }

        #endregion

        #region GetRemainder

        /// <summary>
        /// Numbers are provided, reminder part of number is returned.
        /// </summary>
        /// <param name="numbers">Reminder part of numbers.</param>
        [Trait("Category", "Unit")]
        [Theory]
        [MemberData(nameof(ModesDataForReminder))]
        public void GetReminder_NumbersAreProvided_NumbersInWordIsReturned(KeyValuePair<int, string> numbers)
        {
            // Arrange 
            var uSCurrency = new USCurrency();
            
            // Act 
            var actual = uSCurrency.GetRemainder(numbers.Key);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(numbers.Value, actual);
        }

        #endregion

        #endregion

        #region Tests Data

        /// <summary>
        /// Test data to verify GetReminder method.
        /// </summary>
        public static IEnumerable<object[]> ModesDataForReminder => new List<object[]>
        {
            new object[] { new KeyValuePair<int, string>(0, " ") },
            new object[] { new KeyValuePair<int, string>(7, "Seven Cents") },
            new object[] { new KeyValuePair<int, string>(13, "Thirteen Cents") },
            new object[] { new KeyValuePair<int, string>(99, "Ninety Nine Cents") }
        };

        /// <summary>
        /// Test data to verify GetInteger method.
        /// </summary>
        public static IEnumerable<object[]> ModesDataForInteger => new List<object[]>
        {
            new object[] { new KeyValuePair<int, string>(0, " ") },
            new object[] { new KeyValuePair<int, string>(7, "Seven ") },
            new object[] { new KeyValuePair<int, string>(135, "One Hundred Thirty Five ") },
            new object[] { new KeyValuePair<int, string>(1356, "One Thousand Three Hundreds Fifty Six ") },
            new object[] { new KeyValuePair<int, string>(13567, "Thirteen Thousands Five Hundreds Sixty Seven ") },
            new object[] { new KeyValuePair<int, string>(135676, "One Hundred Thirty Five Thousands Six Hundreds Seventy Six ") },
            new object[] { new KeyValuePair<int, string>(1356763, "One Million Three Hundreds Fifty Six Thousands Seven Hundreds Sixty Three ") },
            new object[] { new KeyValuePair<int, string>(13567633, "Thirteen Millions Five Hundreds Sixty Seven Thousands Six Hundreds Thirty Three ") },
            new object[] { new KeyValuePair<int, string>(135676332, "One Hundred Thirty Five Millions Six Hundreds Seventy Six Thousands Three Hundreds Thirty Two ") },
            new object[] { new KeyValuePair<int, string>(1356763322, "One Billion Three Hundreds Fifty Six Millions Seven Hundreds Sixty Three Thousands Three Hundreds Twenty Two ") }
        };

        #endregion
    }
}
