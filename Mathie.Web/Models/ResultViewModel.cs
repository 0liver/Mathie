using System;

namespace Mathie.Models {
	public class ResultViewModel {
		public string Message { get; set; }

		public TimeSpan? Time { get; set; }

		public string Equation { get; set; }
		public string Solution { get; set; }

		public bool HasSolution { get; set; }
	}

	public class SolutionViewModel {
		public string Equation { get; set; }
		public string Solution { get; set; }
		public int Duration { get; set; }
	}
}