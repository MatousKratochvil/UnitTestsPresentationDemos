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
			public void Addition_ValidInputs_ReturnSum()
			{
				// Arrange
				int numberOne = 15;
				int numberTwo = 15;

				var service = new Service();

				// Act
				int sum = service.AddNonNegativeNumbers(numberOne, numberTwo);

				// Assert
				Assert.Equal(15 + 15, sum);
			}

			[Fact]
			public void Addition_InvalidInput_ThrowException()
			{
				// Arrange
				int numberOne = -15;
				int numberTwo = 15;

				var service = new Service();

				// Act
				var exception = Assert.Throws<InvalidOperationException>(() => service.AddNonNegativeNumbers(numberOne, numberTwo));

				// Assert
				Assert.Equal("EXCEPTION", exception.Message);
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
				public void Addition_ValidInputs_ReturnSum(int numberOne, int numberTwo)
				{
					// Arrange
					var service = new Service();

					// Act
					int sum = service.AddNonNegativeNumbers(numberOne, numberTwo);

					// Assert
					Assert.Equal(numberOne + numberTwo, sum);
				}
			}

			public class ClassData_Attribute
			{
				[Theory]
				[ClassData(typeof(TestDataGenerator))]
				public void Addition_ValidInputs_ReturnSum(int numberOne, int numberTwo)
				{
					// Arrange
					var service = new Service();

					// Act
					int sum = service.AddNonNegativeNumbers(numberOne, numberTwo);

					// Assert
					Assert.Equal(numberOne + numberTwo, sum);
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
				public void Addition_ValidInputs_ReturnSum(int numberOne, int numberTwo)
				{
					// Arrange
					var service = new Service();

					// Act
					int sum = service.AddNonNegativeNumbers(numberOne, numberTwo);

					// Assert
					Assert.Equal(numberOne + numberTwo, sum);
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

				[Theory]
				[MemberData(nameof(TestDataGenerator.GetEvenNumbers), MemberType = typeof(TestDataGenerator))]
				public void Addition_ValidEvenInputs_ReturnSum(int numberOne, int numberTwo)
				{
					// Arrange
					var service = new Service();

					// Act
					int sum = service.AddNonNegativeNumbers(numberOne, numberTwo);

					// Assert
					Assert.Equal(numberOne + numberTwo, sum);
				}

				[Theory]
				[MemberData(nameof(TestDataGenerator.GetOddNumbers), MemberType = typeof(TestDataGenerator))]
				public void Addition_ValidOddInputs_ReturnSum(int numberOne, int numberTwo)
				{
					// Arrange
					var service = new Service();

					// Act
					int sum = service.AddNonNegativeNumbers(numberOne, numberTwo);

					// Assert
					Assert.Equal(numberOne + numberTwo, sum);
				}

				public class TestDataGenerator
				{
					public static IEnumerable<object[]> GetEvenNumbers()
					{
						yield return new object[] { 2, 4 };
						yield return new object[] { 6, 8 };
						yield return new object[] { 10, 12 };
					}

					public static IEnumerable<object[]> GetOddNumbers()
					{
						yield return new object[] { 1, 3 };
						yield return new object[] { 5, 7 };
						yield return new object[] { 9, 11 };
					}
				}

			}

		}
	}
}
