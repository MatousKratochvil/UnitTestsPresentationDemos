
using System.Linq;
using System.Reflection;

using UnitTestsPresentationDemos.Implementation;
using UnitTestsPresentationDemos.Requests;

using Xunit;

namespace UnitTestsPresentationDemosTests
{
	public class UsefulTestsButWrong
	{
		public class ServiceTests
		{
			public class GetAll
			{
				[Fact]
				public void Working_AsIt_Should()
				{
					// Arrange
					var stubRequest = new FakeRequest();
					var stubRepository = new FakeRepository();
					var service = new Service(stubRepository);

					// Act
					var list = service.GetAll(stubRequest);

					// Assert
					Assert.NotEmpty(list.Where(x => x.Text == "FAKE").ToList());
				}

				[Fact]
				public void Working_But_ShouldNot()
				{
					// Arrange
					var stubRequest = new FakeRequest();
					var stubRepository = new FakeRepository();
					var service = new Service(stubRepository);

					// Act
					var list = service.GetAllWrong(stubRequest);

					// Assert
					Assert.NotEmpty(list.Where(x => x.Text == "FAKE").ToList());
				}
			}
		}

	}
}
