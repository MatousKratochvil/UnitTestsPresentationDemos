
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
				public void Service_ValidInput_ReturnCollection()
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
				public void Service_ValidInput_ReturnCollection_WithoutInnerCall()
				{
					// Arrange
					var stubRequest = new FakeRequest();
					var stubRepository = new FakeRepository();
					var service = new Service(stubRepository);

					// Act
					var list = service.GetAllRepositoryNotCalled(stubRequest);

					// Assert
					Assert.NotEmpty(list.Where(x => x.Text == "FAKE").ToList());
				}
			}
		}

	}
}
