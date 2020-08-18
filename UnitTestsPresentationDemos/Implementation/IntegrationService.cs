using System.Collections.Generic;

using UnitTestsPresentationDemos.Abstraction;
using UnitTestsPresentationDemos.Requests;
using UnitTestsPresentationDemos.Responses;

namespace UnitTestsPresentationDemos.Implementation
{
	public class IntegrationService : IService
	{
		readonly IRepository repository;

		public IntegrationService(IRepository repository)
		{
			this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
		}

		public IEnumerable<Response> GetAll(Request request) => repository.GetAll(request);
		public Response Save(Request request) => repository.Save(request);
	}
}
