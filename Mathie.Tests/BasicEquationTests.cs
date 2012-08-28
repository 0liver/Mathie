using MathParserNet;
using NUnit.Framework;

namespace Mathie.Tests {
	/// <summary>
	/// http://www.codeproject.com/Articles/274093/Math-Parser-NET
	/// </summary>
	[TestFixture]
	public class BasicEquationTests {
		[Test]
		public void should_empty_equation_fail() {
			Assert.False(Solve(""));
		}

		[Test]
		public void should_fail_when_equal_sign_at_border() {
			Assert.False(Solve("=234"));
			Assert.False(Solve("3*4*2="));
		}

		[Test]
		public void should_equation_without_equal_sign_fail() {
			Assert.False(Solve("234567"));
		}

		[Test]
		public void should_equation_with_only_equal_sign_solve() {
			Assert.True(Solve("345=345"));
		}

		[Test]
		public void should_equation_with_different_numbers_fail() {
			Assert.False(Solve("123=234"));
		}

		[Test]
		public void should_addition_on_both_sides_work() {
			Assert.True(Solve("1+2+3=3+2+1"));
		}

		[Test]
		public void should_multiplication_work() {
			Assert.True(Solve("3*4*2=6*1*4"));
		}

		[Test]
		public void should_power_work() {
			Assert.True(Solve("3^4*1=80+1"));
		}

		[Test]
		public void should_second_power_precede_first_work() {
			Assert.True(Solve("2^3^2=512"));
			Assert.True(Solve("2^(3^2)=512"));
		}

		[Test]
		public void should_parentheses_precede_power_work() {
			Assert.True(Solve("(2^3)^2=60+4"));
		}

		private static bool Solve(string equation) {
			if (string.IsNullOrWhiteSpace(equation))
				return false;

			if (!equation.Contains("=") ||
			    equation.StartsWith("=") ||
			    equation.EndsWith("="))
				return false;

			equation = equation.Replace("=", "-(") + ")";
			var parser = new Parser();
			var result = parser.Simplify(equation);
			return result.IntValue == 0;
		}
	}
}