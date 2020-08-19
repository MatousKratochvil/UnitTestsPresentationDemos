using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace UnitTestsPresentationDemosTests
{
	public class SharedContextOrdered
	{
        public class DatabaseFixture : IDisposable
        {
            public DatabaseFixture()
            {
                Db = new Stack<int>();
            }

            public void Dispose() => Db = null;

            public Stack<int> Db { get; private set; }
        }

        [CollectionDefinition("Database collection")]
        public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
        {
            // This class has no code, and is never created. Its purpose is simply
            // to be the place to apply [CollectionDefinition] and all the
            // ICollectionFixture<> interfaces.
        }

        [Collection("Database collection")]
        public class DatabaseTestClass1
        {
            DatabaseFixture fixture;

            public DatabaseTestClass1(DatabaseFixture fixture)
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

        [Collection("Database collection")]
        public class DatabaseTestClass2
        {
            DatabaseFixture fixture;

            public DatabaseTestClass2(DatabaseFixture fixture)
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
