using System;

namespace Mathie.Models {
	public class DotNetRandomNumberGenerator : IRandomNumberGenerator {
		private readonly Random _random = new Random();

		public int GetRandomNumber(int min, int max) {
			return _random.Next(min, max);
		}
	}
}