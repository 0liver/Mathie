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
					return RedirectToAction("Index");
				}
				ViewData["Message"] = "Format error - try again!";
				return View();
			}
			ViewData["Message"] = "Sides not equal - try again!";
			return View();
		}

		private string GetRandomNumber() {
			return 342652.ToString();
		}
	}
}