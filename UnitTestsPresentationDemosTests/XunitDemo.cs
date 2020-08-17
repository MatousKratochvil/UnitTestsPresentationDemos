using System;
using System.Collections;
using System.Collections.Generic;

using UnitTestsPresentationDemos.Implementation;

using Xunit;

namespace UnitTestsPresentationDemosTests
{
	public class XunitDemo
	{
		public class Fact_Attribute
		{
			[Fact]
			public void HowItWorks_Working()
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

			[Fact]
			public void HowItWorks_Failing()
			{
				// Arrange
				int numberOne = 15;
				int numberTwo = 15;

				var service = new Service();

				// Act
				int sum = service.Addition(numberOne, numberTwo);

				// Assert
				Assert.Equal(sum, 15);
			}
		}

		public class Theory_Attribute
		{
			public class InlineData_Attribute
			{
				[Theory]
				[InlineData(15, 15)]
				[InlineData(50, 5)]
				[InlineData(80, 897)]
				[InlineData(13215, 564564)]
				public void HowItWorksTheory_Working(int numberOne, int numberTwo)
				{
					// Arrange
					var service = new Service();

					// Act
					int sum = service.Addition(numberOne, numberTwo);

					// Assert
					Assert.Equal(sum, numberOne + numberTwo);
				}

				[Theory]
				[InlineData(15, 15)]
				public void HowItWorksTheory_Failing(int numberOne, int numberTwo)
				{
					// Arrange
					var service = new Service();

					// Act
					int sum = service.Addition(numberOne, numberTwo);

					// Assert
					Assert.Equal(sum, numberOne * numberTwo);
				}
			}

			public class ClassData_Attribute
			{
				[Theory]
				[ClassData(typeof(TestDataGenerator))]
				public void HowItWorksThepry_Working(int numberOne, int numberTwo)
				{
					// Arrange
					var service = new Service();

					// Act
					int sum = service.Addition(numberOne, numberTwo);

					// Assert
					Assert.Equal(sum, numberOne + numberTwo);
				}


				public class TestDataGenerator : IEnumerable<object[]>
				{
					private IEnumerable<object[]> GetNumbersFromDataGenerator()
					{
						yield return new object[] { 5, 1 };
						yield return new object[] { 7, 1 };
						yield return new object[] { 16, 17 };
					}

					public IEnumerator<object[]> GetEnumerator() => GetNumbersFromDataGenerator().GetEnumerator();

					IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
				}
			}

			public class MemberData_Attribute
			{

				[Theory]
				[MemberData(nameof(GetNumbers))]
				public void HowItWorksTheory_Working(int numberOne, int numberTwo)
				{
					// Arrange
					var service = new Service();

					// Act
					int sum = service.Addition(numberOne, numberTwo);

					// Assert
					Assert.Equal(sum, numberOne + numberTwo);
				}


				public static IEnumerable<object[]> GetNumbers()
				{
					yield return new object[] { 5, 1 };
					yield return new object[] { 7, 1 };
					yield return new object[] { 16, 17 };
					yield return new object[] { 5, 1 };
					yield return new object[] { 7, 1 };
					yield return new object[] { 16, 17 };
				}
			}

		}
	}
}
