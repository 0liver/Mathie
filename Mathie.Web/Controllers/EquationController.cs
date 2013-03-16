using System;
using System.Web.Mvc;
using Mathie.Models;

namespace Mathie.Controllers {
	public class EquationController : Controller {
		[HttpGet]
		public ActionResult Index() {
			var randomString = new EquationGenerator(new DotNetRandomNumberGenerator()).GetEquation();
			var resultViewModel = new ResultViewModel { Equation = randomString, Solution = randomString };
			return View(resultViewModel);
		}

		[HttpPost]
		public ActionResult Index(SolutionViewModel solutionViewModel) {
			var resultViewModel = new ResultViewModel();
			var solver = new EquationSolver();
			if (solver.IsInCorrectFormat(solutionViewModel.Solution)) {
				if (solver.Solve(solutionViewModel.Solution)) {
					resultViewModel.HasSolution = true;
					resultViewModel.Message = "Well done :) ";
					resultViewModel.Time = TimeSpan.FromSeconds(solutionViewModel.Duration);
					resultViewModel.Equation = solutionViewModel.Equation;
					resultViewModel.Solution = solver.Format(solutionViewModel.Solution);
				}
				else {
					resultViewModel.Message = "Sides not equal - try again!";
				}
			}
			else {
				resultViewModel.Message = "Format error - try again!";
			}
			return View(resultViewModel);
		}

		public string Test(string name, int? id) {
			return string.Format("Name: '{0}', Id: {1}", Server.HtmlEncode(name), id);
		}
	}
}