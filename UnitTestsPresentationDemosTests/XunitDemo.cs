using System;

using UnitTestsPresentationDemos.Implementation;

using Xunit;

namespace UnitTestsPresentationDemosTests
{
	public class XunitDemo
	{
		[Fact]
		public void HowItWorks()
		{
			// Arrange
			int numberOne = 15;
			int numberTwo = 15;

			var service = new Service();

			// Act
			int sum = service.Addition(numberOne, numberTwo);

			// Assert
			Assert.Equal(sum, 15 + 15);
		}
	}
}
