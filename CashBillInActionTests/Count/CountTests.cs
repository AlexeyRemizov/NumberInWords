using System;
using System.Collections.Generic;
using CashBillInAction.Count;
using CashBillInAction.Currency;
using CashBillInAction.IOServices;
using Moq;
using Xunit;

namespace CashBillInActionTests
{
    /// <summary>
    /// Test class.
    /// </summary>
    public class CountTests
    {
        #region Tests

        #region .ctor

        /// <summary>
        /// Null InputService instance is provided, ArgumentNullException is thrown.
        /// </summary>
        [Trait("Category", "Unit")]
        [Fact]
        public void Count_NullInputServiceIsProvided_ArgumentNullExceptionIsThrown()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new Count(null, new Mock<ICurrency>().Object));
        }

        /// <summary>
        /// Null Currency instance is provided, ArgumentNullException is thrown.
        /// </summary>
        [Trait("Category", "Unit")]
        [Fact]
        public void Count_NullCurrency_ArgumentNullExceptionIsThrown()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new Count(new Mock<IInputService>().Object, null));
        }

        #endregion

        #region Validate

        /// <summary>
        /// Number in English format is provided, broken number is returned.
        /// </summary>
        [Trait("Category", "Unit")]
        [Fact]
        public void Validate_NumberInEnglishIsProvided_BrokenNumberIsReturned()
        {
            // Arrange
            var inputService = new Mock<IInputService>();
            inputService.Setup(x => x.Readout()).Returns(new KeyValuePair<int,string>(1, "1234.6"));
            var count = new Count(inputService.Object, new Mock<ICurrency>().Object);
            var expected = new KeyValuePair<int, int>(1234, 6);

            // Act
            var actual = count.Validate();

            // Assert
            Assert.Equal(expected.Key, actual.Key);
            Assert.Equal(expected.Value, actual.Value);
        }

        /// <summary>
        /// Fake format is provided, Exception is thrown.
        /// </summary>
        [Trait("Category", "Unit")]
        [Fact]
        public void Validate_FakeFlagUSIsProvided_ExceptionIsThrown()
        {
            // Arrange
            var inputService = new Mock<IInputService>();
            inputService.Setup(x => x.Readout()).Returns(new KeyValuePair<int, string>(1, "1234,6"));
            var count = new Count(inputService.Object, new Mock<ICurrency>().Object);

            // Act
            // Assert
            Assert.Throws<Exception>(() => count.Validate());
        }

        /// <summary>
        /// Number in Ukrainian format is provided, broken number is returned.
        /// </summary>
        [Trait("Category", "Unit")]
        [Fact]
        public void Validate_NumberInUkrainianIsProvided_BrokenNumberIsReturned()
        {
            // Arrange
            var inputService = new Mock<IInputService>();
            inputService.Setup(x => x.Readout()).Returns(new KeyValuePair<int, string>(2, "1234,6"));
            var count = new Count(inputService.Object, new Mock<ICurrency>().Object);
            var expected = new KeyValuePair<int, int>(1234, 6);

            // Act
            var actual = count.Validate();

            // Assert
            Assert.Equal(expected.Key, actual.Key);
            Assert.Equal(expected.Value, actual.Value);
        }

        /// <summary>
        /// Fake format is provided, Exception is thrown.
        /// </summary>
        [Trait("Category", "Unit")]
        [Fact]
        public void Validate_FakeFlagUkrIsProvided_ExceptionIsThrown()
        {
            // Arrange
            var inputService = new Mock<IInputService>();
            inputService.Setup(x => x.Readout()).Returns(new KeyValuePair<int, string>(2, "1234.6"));
            var count = new Count(inputService.Object, new Mock<ICurrency>().Object);

            // Act
            // Assert
            Assert.Throws<Exception>(() => count.Validate());
        }

        /// <summary>
        /// Invalid number is provided, Exception is thrown.
        /// </summary>
        [Trait("Category", "Unit")]
        [Fact]
        public void Validate_InvalidNumberIsProvided_ExceptionIsThrown()
        {
            // Arrange
            var inputService = new Mock<IInputService>();
            inputService.Setup(x => x.Readout()).Returns(new KeyValuePair<int, string>(2, " 2147483649,06"));
            var count = new Count(inputService.Object, new Mock<ICurrency>().Object);

            // Act
            // Assert
            Assert.Throws<Exception>(() => count.Validate());
        }

        /// <summary>
        /// Invalid number is provided, Exception is thrown.
        /// </summary>
        [Trait("Category", "Unit")]
        [Fact]
        public void Validate_NumberWithInvalidRemainderIsProvided_ExceptionIsThrown()
        {
            var inputService = new Mock<IInputService>();
            inputService.Setup(x => x.Readout()).Returns(new KeyValuePair<int, string>(2, " 214748364,069"));
            var count = new Count(inputService.Object, new Mock<ICurrency>().Object);

            // Act
            // Assert
            Assert.Throws<Exception>(() => count.Validate());
        }

        /// <summary>
        /// Incorrect number is provided, Exception is thrown.
        /// </summary>
        [Trait("Category", "Unit")]
        [Fact]
        public void Validate_IncorrectNumberIsProvided_ExceptionIsThrown()
        {
            var inputService = new Mock<IInputService>();
            inputService.Setup(x => x.Readout()).Returns(new KeyValuePair<int, string>(2, " 214748364"));
            var count = new Count(inputService.Object, new Mock<ICurrency>().Object);

            // Act
            // Assert
            Assert.Throws<Exception>(() => count.Validate());
        }

        #endregion

        #region CashBill

        /// <summary>
        /// Number in English format is provided, number in words is returned.
        /// </summary>
        [Trait("Category", "Unit")]
        [Fact]
        public void CashBill_NumberInEnglishIsProvided_NumberInWordsIsReturned()
        {
            // Arrange
            var inputService = new Mock<IInputService>();
            inputService.Setup(x => x.Readout()).Returns(new KeyValuePair<int, string>(1, "123.45"));
            var currency = new Mock<ICurrency>();
            currency.Setup(x => x.GetInteger(123)).Returns("One Hundred Twenty Three ");
            currency.Setup(x => x.GetRemainder(45)).Returns("Forty Five Cents");
            var count = new Count(inputService.Object, currency.Object);
            var expected = "One Hundred Twenty Three Dollars Forty Five Cents";

            // Act
            var actual = count.CashBill();

            // Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Number in Ukrainian format is provided, number in words is returned.
        /// </summary>
        [Trait("Category", "Unit")]
        [Fact]
        public void CashBill_NumberInUkrainianIsProvided_NumberInWordsIsReturned()
        {
            // Arrange
            var inputService = new Mock<IInputService>();
            inputService.Setup(x => x.Readout()).Returns(new KeyValuePair<int, string>(2, "123,45"));
            var currency = new Mock<ICurrency>();
            currency.Setup(x => x.GetInteger(123)).Returns("Одна Сотня Двадцять Три ");
            currency.Setup(x => x.GetRemainder(45)).Returns("Сорок П`ять Копiйок");
            var count = new Count(inputService.Object, currency.Object);
            var expected = "Одна Сотня Двадцять Три Гривень Сорок П`ять Копiйок";

            // Act
            var actual = count.CashBill();

            // Assert
            Assert.Equal(expected, actual);
        }

        #endregion

        #endregion
    }
}
