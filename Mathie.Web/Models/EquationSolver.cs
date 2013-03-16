using System.Linq;
using System.Text;
using MathParserNet;

namespace Mathie.Models {
	public class EquationSolver : IEquationSolver {
		public bool IsInCorrectFormat(string equation) {
			if (string.IsNullOrWhiteSpace(equation)) {
				return false;
			}

			if (!equation.StartsWith("=") &&
			    !equation.EndsWith("=") &&
			    equation.Count(c => c == '=') == 1) {
				return true;
			}

			return false;
		}

		public bool Solve(string equation) {
			if (!IsInCorrectFormat(equation)) {
				return false;
			}

			equation = equation.Replace(" ", "").Replace("=", "-(") + ")";
			var parser = new Parser();
			try {
				var result = parser.Simplify(equation);
				return result.IntValue == 0;
			}
			catch (System.InvalidOperationException) {
				return false;
			}
		}

		public string Format(string solution) {
			var validBeforeUnary = new[] { '+', '-', '*', '/', '=' };
			solution = solution.Replace(" ", "");
			var stringBuilder = new StringBuilder();
			var lastChar = (char) 0;
			var secondLastChar = (char) 0;
			foreach (var character in solution) {
				// first character
				if (lastChar == (char) 0) {
					stringBuilder.Append(character);
				}
				else {
					if (IsDigit(character)) {
						if (!IsDigit(lastChar) && (lastChar != '-' || !validBeforeUnary.Contains(secondLastChar))) {
							stringBuilder.Append(' ');
						}
						stringBuilder.Append(character);
					}
					else {
						stringBuilder.Append(' ').Append(character);
					}
				}
				secondLastChar = lastChar;
				lastChar = character;
			}
			return stringBuilder.ToString();
		}

		private bool IsDigit(char character) {
			return character >= '0' && character <= '9';
		}
	}
}