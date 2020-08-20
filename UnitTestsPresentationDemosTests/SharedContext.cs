using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace UnitTestsPresentationDemosTests
{
	public class SharedContext
	{
        public class StackFixture : IDisposable
        {
			public StackFixture()
			{
				Db = new Stack<int>();
			}

			public void Dispose() => Db = null;

			public Stack<int> Db { get; private set; }
        }

        public class StackFixtureTest : IClassFixture<StackFixture>
        {
			readonly StackFixture fixture;

            public StackFixtureTest(StackFixture fixture)
            {
                this.fixture = fixture;
            }


            [Theory]
            [InlineData(25)]
            [InlineData(45)]
            [InlineData(55)]
            [InlineData(65)]
            [InlineData(78)]
            public void AfterPushingItem_CountShouldReturnOne(int item)
            {
                fixture.Db.Push(item);

				int fixtureCount = fixture.Db.Count;

                Assert.Equal(fixture.Db.Count, fixtureCount);
            }
        }
    }
}
