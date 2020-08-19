
using System.Linq;
using System.Threading.Tasks;

using UnitTestsPresentationDemos.Implementation;
using UnitTestsPresentationDemos.Requests;

using Xunit;

namespace UnitTestsPresentationDemosTests
{
	public class IntegrationTest
	{
		[Fact]
		public async Task ServiceRepositoryIntegrationOrUnit()
		{
			// Arrange
			var repository = new IsItUnitOrIntegrationRepository();
			var service = new IntegrationService(repository);

			// Act
			var response = await service.GetAllAsync(new Request());

			// Assert
			Assert.Equal(10, response.Count());
		}

		[Fact]
		public async Task ServiceRepositoryUnitOrIntegration()
		{
			// Arrange
			var repository = new IsItIntegrationOrUnitRepository();
			var service = new IntegrationService(repository);

			// Act
			var response = await service.GetAllAsync(new Request());

			// Assert
			Assert.Equal(10, response.Count());
		}
	}
}
