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

            // Mocking rules for specific numbers
            var mockFizzRule = new Mock<IFizzBuzzRule>();
            var mockBuzzRule = new Mock<IFizzBuzzRule>();
            var mockFizzBuzzRule = new Mock<IFizzBuzzRule>();
            var mockNumberTwoRule = new Mock<IFizzBuzzRule>();
            var mockNumberTwentyFiveRule = new Mock<IFizzBuzzRule>();
            var mockNumberTwentyOneRule = new Mock<IFizzBuzzRule>();

            mockFactory.Setup(f => f.CreateRule(3)).Returns(mockFizzRule.Object);
            mockFactory.Setup(f => f.CreateRule(5)).Returns(mockBuzzRule.Object);
            mockFactory.Setup(f => f.CreateRule(15)).Returns(mockFizzBuzzRule.Object);
            mockFactory.Setup(f => f.CreateRule(2)).Returns(mockNumberTwoRule.Object);
            mockFactory.Setup(f => f.CreateRule(25)).Returns(mockNumberTwentyFiveRule.Object);
            mockFactory.Setup(f => f.CreateRule(21)).Returns(mockNumberTwentyOneRule.Object);

            // Setting up expected results
            mockFizzRule.Setup(r => r.GetResult()).Returns("Fizz");
            mockBuzzRule.Setup(r => r.GetResult()).Returns("Buzz");
            mockFizzBuzzRule.Setup(r => r.GetResult()).Returns("FizzBuzz");
            mockNumberTwoRule.Setup(r => r.GetResult()).Returns("Divided 2 by 3\nDivided 2 by 5");
            mockNumberTwentyFiveRule.Setup(r => r.GetResult()).Returns("Buzz");
            mockNumberTwentyOneRule.Setup(r => r.GetResult()).Returns("Fizz");

            var service = new FizzBuzzService(mockFactory.Object);
            var input = new List<string> { "1", "3", "15", "", "abc", "2", "25", "21" };

            // Act
            var result = await service.GetFizzBuzzResults(input);

            // Assert
            Assert.AreEqual(8, result.Results.Count);
            Assert.AreEqual("Divided 1 by 3\nDivided 1 by 5", result.Results[0]);
            Assert.AreEqual("Fizz", result.Results[1]);
            Assert.AreEqual("FizzBuzz", result.Results[2]);
            Assert.AreEqual("Invalid item", result.Results[3]); // Empty string
            Assert.AreEqual("Invalid item", result.Results[4]); // Non-numeric string
            Assert.AreEqual("Divided 2 by 3\nDivided 2 by 5", result.Results[5]);
            Assert.AreEqual("Buzz", result.Results[6]);
            Assert.AreEqual("Fizz", result.Results[7]);
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
