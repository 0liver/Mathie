using Mathie.Models;
using NUnit.Framework;

namespace Mathie.Tests {
	[TestFixture]
	public class EquationFormatTest {
		private IEquationSolver _formatter;

		[SetUp]
		public void Setup() {
			_formatter = new EquationSolver();
		}

		[Test]
		public void Should_add_spaces_around_single_sign() {
			Assert.AreEqual("3 + 5", _formatter.Format("3+5"));
		}

		[Test]
		public void Should_add_single_space_between_signs() {
			Assert.AreEqual("3 ) - 2", _formatter.Format("3)-2"));
		}

		[Test]
		public void Should_not_add_space_at_beginning_or_end() {
			Assert.AreEqual("( 3 ) - ( 2 )", _formatter.Format("(3)-(2)"));
		}

		[Test]
		public void Should_not_add_space_before_unary_minus() {
			Assert.AreEqual("3 + -2", _formatter.Format("3+-2"));
			Assert.AreEqual("3 - -2", _formatter.Format("3--2"));
			Assert.AreEqual("3 * -2", _formatter.Format("3*-2"));
			Assert.AreEqual("3 / -2", _formatter.Format("3/-2"));
			Assert.AreEqual("3 = -2", _formatter.Format("3=-2"));
		}

		[Test]
		public void Should_correctly_format_complex_equation() {
			Assert.AreEqual("( ( 3 + 2 ) ^ ( 2 - 1 ) = 8 / 4", _formatter.Format("((3+2)^(2-1)=8/4"));
			Assert.AreEqual("( 9 + 9 ) * 1 = ( 8 % 6 ) * 9", _formatter.Format("(9  +9 ) *1=(8%6) * 9"));
		}
	}
}