using System;
using System.Collections.Generic;
using System.Linq;

namespace Mathie.Models {
	public class EquationGenerator : IEquationGenerator {
		private readonly IRandomNumberGenerator _randomNumberGenerator;

		public EquationGenerator(IRandomNumberGenerator randomNumberGenerator) {
			_randomNumberGenerator = randomNumberGenerator;
		}

		public string GetEquation() {
			string equationBase = null;
			// try random numbers until we find one with less than 2 zeros
			while (!IsEquationValid(equationBase)) {
				var number = _randomNumberGenerator.GetRandomNumber(1, 1000000);
				equationBase = number.ToString("0  0  0 = 0  0  0");
			}
			return equationBase;
		}

		private static bool IsEquationValid(string equation) {
			return GetValidityRules().All(rule => rule(equation));
		}

		private static IEnumerable<Func<string, bool>> GetValidityRules() {
			yield return eq => !string.IsNullOrEmpty(eq);
			yield return eq => eq.Count(c => c == '0') <= 1;
			yield return eq => {
			             	var sides = eq.Replace(" ", "").Split('=');
			             	return sides[0] != sides[1];
			             };
		}
	}
}