using System.Collections.Generic;
using System.Threading.Tasks;

using UnitTestsPresentationDemos.Abstraction;
using UnitTestsPresentationDemos.Requests;
using UnitTestsPresentationDemos.Responses;

namespace UnitTestsPresentationDemos.Implementation
{
	public class IntegrationService
	{
		readonly IRepositoryAsync repository;

		public IntegrationService(IRepositoryAsync repository)
		{
			this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
		}

		public Task<IEnumerable<Response>> GetAllAsync(Request request) => repository.GetAllAsync(request);
		public Task<Response> SaveAsync(Request request) => repository.SaveAsync(request);
	}
}
