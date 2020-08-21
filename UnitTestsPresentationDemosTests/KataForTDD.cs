using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

using Xunit;

namespace UnitTestsPresentationDemosTests
{
	// KATA (Problem) can be found at http://www.butunclebob.com/ArticleS.UncleBob.ThePrimeFactorsKata
	// I personaly have it from presentation by Robert C. Martin (Uncle Bob)

	public class KataForTDD
	{
		public IEnumerable<int> PrimeFactor(int number)
		{
			var primes = new List<int>();

			return primes;
		}

		[Fact]
		public void FactorOfTest()
		{
		}

		private static List<int> List(params int[] arr)
		{
			if (arr.Any())
				return arr.ToList();
			return new List<int>();
		}

		public static class Testing
		{
			public static void Equivalent<T>(IEnumerable<T> expected, IEnumerable<T> actual)
				=>
					Assert.True(expected.OrderBy(i => i).SequenceEqual(actual.OrderBy(i => i)));
		}
	}
}