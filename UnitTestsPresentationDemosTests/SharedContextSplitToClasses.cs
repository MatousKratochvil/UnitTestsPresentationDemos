using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace UnitTestsPresentationDemosTests
{
	public class SharedContextSplitToClasses
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

        [CollectionDefinition("Stack collection")]
        public class StackCollection : ICollectionFixture<StackFixture>
        {
            // This class has no code, and is never created. Its purpose is simply
            // to be the place to apply [CollectionDefinition] and all the
            // ICollectionFixture<> interfaces.
        }

        [Collection("Stack collection")]
        public class StackTestClass1
        {
			readonly StackFixture fixture;

            public StackTestClass1(StackFixture fixture)
            {
                this.fixture = fixture;
            }

            [Fact]
            public void AfterPushingItem_CountShouldReturnOne()
            {
                fixture.Db.Push(42);

                int fixtureCount = fixture.Db.Count;

                Assert.Equal(1, fixtureCount);
            }
        }

        [Collection("Stack collection")]
        public class StackTestClass2
        {
			readonly StackFixture fixture;

            public StackTestClass2(StackFixture fixture)
            {
                this.fixture = fixture;
            }

            [Fact]
            public void AfterPushingItem_CountShouldReturnOne()
            {
                fixture.Db.Push(42);

                int fixtureCount = fixture.Db.Count;

                Assert.Equal(2, fixtureCount);
            }
        }
    }
}
