using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace UnitTestsPresentationDemosTests
{
	public class ContextTest
	{
		public class ContextUniqueForTests : IDisposable
		{
            Stack<int> stack;

			public ContextUniqueForTests()
			{
				stack = new Stack<int>();
			}

			public void Dispose() => stack = null;

			[Fact]
            public void WithNoItems_CountShouldReturnZero()
            {
				int count = stack.Count;

                Assert.Equal(0, count);
            }

            [Theory]
            [InlineData(25)]
            [InlineData(45)]
            [InlineData(55)]
            [InlineData(65)]
            [InlineData(78)]
            public void AfterPushingItem_CountShouldReturnOne(int item)
            {
                stack.Push(item);

				int count = stack.Count;

                Assert.Equal(1, count);
            }
        }
	}
}
