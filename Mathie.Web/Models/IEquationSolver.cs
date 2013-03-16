namespace Mathie.Models {
	public interface IEquationSolver {
		bool IsInCorrectFormat(string equation);
		bool Solve(string equation);
		string Format(string solution);
	}
}