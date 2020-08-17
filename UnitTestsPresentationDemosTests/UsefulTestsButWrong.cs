
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
				public void WorkingAndShould()
				{
					// Arrange
					var fakeRequest = new FakeRequest();
					var fakeRepository = new FakeRepository();
					var service = new Service(fakeRepository);

					// Act
					var list = service.GetAll(fakeRequest);

					// Assert
					Assert.NotEmpty(list.Where(x => x.Text == "FAKE").ToList());
				}

				[Fact]
				public void WorkingAndShouldNot()
				{
					// Arrange
					var fakeRequest = new FakeRequest();
					var fakeRepository = new FakeRepository();
					var service = new Service(fakeRepository);

					// Act
					var list = service.GetAllWrong(fakeRequest);

					// Assert
					Assert.NotEmpty(list.Where(x => x.Text == "FAKE").ToList());
				}
			}


		}

	}
}
