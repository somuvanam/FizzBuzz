using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using FizzBuzz.Services;
using FizzBuzz.Factories;
using FizzBuzz.Services.Rules;

namespace FizzBuzz.Tests
{
    [TestFixture]
    public class FizzBuzzServiceTests
    {
        [Test]
        public async Task GetFizzBuzzResults_ValidNumber_ReturnsFizzBuzz()
        {
            // Arrange
            var mockFactory = new Mock<IFizzBuzzRuleFactory>();
            var mockRule = new Mock<IFizzBuzzRule>();
            mockFactory.Setup(f => f.CreateRule(It.IsAny<int>())).Returns(mockRule.Object);
            mockRule.Setup(r => r.GetResult()).Returns("FizzBuzz");

            var service = new FizzBuzzService(mockFactory.Object);
            var input = new List<string> { "15" }; // "15" should trigger FizzBuzz

            // Act
            var result = await service.GetFizzBuzzResults(input);

            // Assert
            Assert.AreEqual(1, result.Results.Count);
            Assert.AreEqual("FizzBuzz", result.Results[0]);
        }

        [Test]
        public async Task GetFizzBuzzResults_ValidNumber_ReturnsFizz()
        {
            // Arrange
            var mockFactory = new Mock<IFizzBuzzRuleFactory>();
            var mockRule = new Mock<IFizzBuzzRule>();
            mockFactory.Setup(f => f.CreateRule(It.IsAny<int>())).Returns(mockRule.Object);
            mockRule.Setup(r => r.GetResult()).Returns("Fizz");

            var service = new FizzBuzzService(mockFactory.Object);
            var input = new List<string> { "3" }; // "3" should trigger Fizz

            // Act
            var result = await service.GetFizzBuzzResults(input);

            // Assert
            Assert.AreEqual(1, result.Results.Count);
            Assert.AreEqual("Fizz", result.Results[0]);
        }

        [Test]
        public async Task GetFizzBuzzResults_ValidNumber_ReturnsBuzz()
        {
            // Arrange
            var mockFactory = new Mock<IFizzBuzzRuleFactory>();
            var mockRule = new Mock<IFizzBuzzRule>();
            mockFactory.Setup(f => f.CreateRule(It.IsAny<int>())).Returns(mockRule.Object);
            mockRule.Setup(r => r.GetResult()).Returns("Buzz");

            var service = new FizzBuzzService(mockFactory.Object);
            var input = new List<string> { "5" }; // "5" should trigger Buzz

            // Act
            var result = await service.GetFizzBuzzResults(input);

            // Assert
            Assert.AreEqual(1, result.Results.Count);
            Assert.AreEqual("Buzz", result.Results[0]);
        }

        [Test]
        public async Task GetFizzBuzzResults_InvalidNumber_ReturnsInvalidItem()
        {
            // Arrange
            var mockFactory = new Mock<IFizzBuzzRuleFactory>();
            var service = new FizzBuzzService(mockFactory.Object);
            var input = new List<string> { "abc" }; // "abc" is not a valid number

            // Act
            var result = await service.GetFizzBuzzResults(input);

            // Assert
            Assert.AreEqual(1, result.Results.Count);
            Assert.AreEqual("Invalid item", result.Results[0]);
        }

        [Test]
        public async Task GetFizzBuzzResults_MixedInput_ReturnsMixedResults()
        {
            // Arrange
            var mockFactory = new Mock<IFizzBuzzRuleFactory>();
            var mockFizzBuzzRule = new Mock<IFizzBuzzRule>();
            var mockBuzzRule = new Mock<IFizzBuzzRule>();
            var mockDefaultRule = new Mock<IFizzBuzzRule>();

            // Setting up rules for specific numbers
            mockFactory.Setup(f => f.CreateRule(15)).Returns(mockFizzBuzzRule.Object);
            mockFactory.Setup(f => f.CreateRule(20)).Returns(mockBuzzRule.Object);

            // Default rule setup for numbers not specifically mocked
            mockFactory.Setup(f => f.CreateRule(It.IsAny<int>())).Returns(mockDefaultRule.Object);

            // Setting up the expected results
            mockFizzBuzzRule.Setup(r => r.GetResult()).Returns("FizzBuzz");
            mockBuzzRule.Setup(r => r.GetResult()).Returns("Buzz");
            mockDefaultRule.Setup(r => r.GetResult()).Returns("Invalid item");

            var service = new FizzBuzzService(mockFactory.Object);
            var input = new List<string> { "15", "abc", "20" };

            // Act
            var result = await service.GetFizzBuzzResults(input);

            // Assert
            Assert.AreEqual(3, result.Results.Count);
            Assert.AreEqual("FizzBuzz", result.Results[0]);
            Assert.AreEqual("Invalid item", result.Results[1]);
            Assert.AreEqual("Buzz", result.Results[2]);
        }


        [Test]
        public async Task GetFizzBuzzResults_EmptyInput_ReturnsEmptyResults()
        {
            // Arrange
            var mockFactory = new Mock<IFizzBuzzRuleFactory>();
            var service = new FizzBuzzService(mockFactory.Object);
            var input = new List<string>(); // Empty input list

            // Act
            var result = await service.GetFizzBuzzResults(input);

            // Assert
            Assert.IsEmpty(result.Results);
        }
    }
}
