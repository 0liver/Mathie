using System.Linq;
using MathParserNet;

namespace Mathie.Models {
	public class EquationSolver {
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
			var result = parser.Simplify(equation);
			return result.IntValue == 0;
		}
	}
}