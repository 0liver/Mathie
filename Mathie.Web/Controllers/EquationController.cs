using System;
using System.Linq;
using System.Web.Mvc;
using Mathie.Models;

namespace Mathie.Controllers {
	public class EquationController : Controller {
		[HttpGet]
		public ActionResult Index() {
			var randomNumber = GetRandomNumber();
			return View((object) randomNumber);
		}

		[HttpPost]
		public ActionResult Index(string equation) {
			var solver = new EquationSolver();
			if (solver.IsInCorrectFormat(equation)) {
				if (solver.Solve(equation)) {
					ViewData["Message"] = "Well done :)";
				}
				else {
					ViewData["Message"] = "Format error - try again!";
				}
				return View();
			}
			ViewData["Message"] = "Sides not equal - try again!";
			return View();
		}

		private string GetRandomNumber() {
			var equationBase = "00";
			while (equationBase.Count(c => c == '0') >= 2) {
				var number = new Random().Next(1, 1000000);
				equationBase = number.ToString("0  0  0 = 0  0  0");
			}
			return equationBase;
		}
	}
}