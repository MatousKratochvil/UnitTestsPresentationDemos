
using System.Linq;

using UnitTestsPresentationDemos.Implementation;
using UnitTestsPresentationDemos.Requests;

using Xunit;

namespace UnitTestsPresentationDemosTests
{
	public class IntegrationTest
	{
		[Fact]
		public void ServiceRepositoryIntegration()
		{
			// Arrange
			var repository = new IntegrationRepository();
			var service = new IntegrationService(repository);

			// Act
			var response = service.GetAll(new Request());

			// Assert
			Assert.Equal(100, response.Count());
		}
	}
}
