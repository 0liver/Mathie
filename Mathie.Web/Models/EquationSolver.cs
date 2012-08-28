using System;
using System.Linq;
using MathParserNet;

namespace Mathie.Models {
	public class EquationSolver {
		public bool IsInCorrectFormat(string equation) {
			if (string.IsNullOrWhiteSpace(equation)) {
				return false;
			}

			if (equation.StartsWith("=") ||
				equation.EndsWith("=") ||
				equation.Count(c => c == '=') != 1) {
				return false;
			}

			return true;
		}

		public bool Solve(string equation) {
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