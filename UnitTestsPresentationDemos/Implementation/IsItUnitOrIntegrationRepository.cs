using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UnitTestsPresentationDemos.Abstraction;
using UnitTestsPresentationDemos.Requests;
using UnitTestsPresentationDemos.Responses;

namespace UnitTestsPresentationDemos.Implementation
{
	public class IsItUnitOrIntegrationRepository : IRepositoryAsync
	{
		public Task<IEnumerable<Response>> GetAllAsync(Request request)
			=>
				new ValueTask<IEnumerable<Response>>(Enumerable.Range(0, 10)
				.Select(x => new Response { Text = x.ToString() })).AsTask();
		public Task<Response> SaveAsync(Request request)
			=>
				new ValueTask<Response>(new Response { Text = "true" }).AsTask();

	}
}

