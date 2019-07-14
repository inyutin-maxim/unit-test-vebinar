using System;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace UnitTesting.Tests
{
    public class AutomatTests
    {
        [Fact]
        public void GetMoney()
        {
            // Arrange
            var mocker = new AutoMocker();
            var instance = mocker.CreateInstance<Automat>();
            // Act
            var money = instance.GetMoney(10);
            // Assert
            Assert.True(money);
        }

        [Fact]
        public void GetMoney_OnlyPositiveMoneyValue()
        {
            // Arrange
            var mocker = new AutoMocker();
            var instance = mocker.CreateInstance<Automat>();
            // Act
            var money = instance.GetMoney(-10);
            // Assert
            Assert.False(money);
        }

        [Fact]
        public void GetMoney_MoneyNotEqualZero()
        {
            // Arrange
            var mocker = new AutoMocker();
            var instance = mocker.CreateInstance<Automat>();
            // Act
            var money = instance.GetMoney(0);
            // Assert
            Assert.False(money);
        }

        [Fact]
        public void TakeFood_NoCredits()
        {
            // Arrange
            var mocker = new AutoMocker();
            var instance = mocker.CreateInstance<Automat>();
            // Act

            // Assert
            Assert.Throws<NullReferenceException>(() => instance.TakeFood());
        }

        [Fact]
        public void TakeFood_CreditsMoreThanZero()
        {
            // Arrange
            var mocker = new AutoMocker();
            mocker.Setup<ILogger<Automat>, bool>(x => x.IsEnabled(LogLevel.Critical)).Returns(true);

            var instance = mocker.CreateInstance<Automat>();
            // Act
            instance.GetMoney(10);
            var food = instance.TakeFood();
            // Assert
            Assert.NotNull(food);
        }

        [Fact]
        public void ILogger_IsEnabled_tru()
        {
            // Arrange
            var mocker = new AutoMocker();
            mocker.Setup<ILogger<Automat>, bool>(x => x.IsEnabled(LogLevel.Critical)).Returns(true);

            var instance = mocker.CreateInstance<Automat>();
            // Act
            instance.GetMoney(10);
            // Assert
            mocker.GetMock<ILogger<Automat>>().Verify(x => x.IsEnabled(LogLevel.Critical));
        }
    }
}
