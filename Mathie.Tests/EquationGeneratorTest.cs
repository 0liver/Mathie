using Mathie.Models;
using Moq;
using NUnit.Framework;

namespace Mathie.Tests {
	[TestFixture]
	public class EquationGeneratorTest {
		[Test]
		public void Should_not_generate_identical_sides() {
			var randomNumberGenerator = new Mock<IRandomNumberGenerator>();
			var equationGenerator = new EquationGenerator(randomNumberGenerator.Object);
			var counter = 1;
			randomNumberGenerator.Setup(g => g.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>()))
				.Returns(() => counter++ == 1 ? 123123 : 123456);
			Assert.AreEqual("123=456", equationGenerator.GetEquation().Replace(" ", ""));
		}
	}
}