using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace UnitTestsPresentationDemosTests
{
	public class KataForTDDFinal
	{
		public IEnumerable<int> PrimeFactor(int number)
		{
			var primes = new List<int>();

			for (int candidate = 2; number > 1; candidate++)
				for (; number % candidate == 0; number /= candidate)
					primes.Add(candidate);

			return primes;
		}

		[Fact]
		public void FactorOfTest()
		{
			Testing.Equivalent(List(), PrimeFactor(1));
			Testing.Equivalent(List(2), PrimeFactor(2));
			Testing.Equivalent(List(3), PrimeFactor(3));
			Testing.Equivalent(List(2, 2), PrimeFactor(4));
			Testing.Equivalent(List(2, 3), PrimeFactor(6));
			Testing.Equivalent(List(2, 2, 2), PrimeFactor(8));
			Testing.Equivalent(List(3, 3), PrimeFactor(9));
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
