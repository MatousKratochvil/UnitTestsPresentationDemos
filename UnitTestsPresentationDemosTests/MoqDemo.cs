
using System.Collections.Generic;
using System.Linq;

using Moq;

using UnitTestsPresentationDemos.Abstraction;
using UnitTestsPresentationDemos.Implementation;
using UnitTestsPresentationDemos.Requests;
using UnitTestsPresentationDemos.Responses;

using Xunit;

namespace UnitTestsPresentationDemosTests
{
	public class MoqDemo
	{
		public class ServiceTest
		{
			public class GetAll
			{
				[Fact]
				public void Service_CallsRepository_VerifiedCall()
				{
					// Arrange
					var stubRequest = new FakeRequest();
					var mockRepository = new Mock<IRepository>();

					_ = mockRepository
						.Setup(x => x.GetAll(It.IsAny<Request>()))
						.Returns(new List<Response> { new FakeResponse() });

					var service = new Service(mockRepository.Object);

					// Act
					var list = service.GetAll(stubRequest);

					// Assert
					mockRepository.Verify(x => x.GetAll(It.IsAny<Request>()), Times.Once);

					Assert.NotEmpty(list.Where(x => x.Text == "FAKE").ToList());
				}
			}
		}
	}
}
