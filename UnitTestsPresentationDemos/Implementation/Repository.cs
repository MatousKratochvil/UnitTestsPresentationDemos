
using System.Collections.Generic;
using System.Linq;

using UnitTestsPresentationDemos.Abstraction;
using UnitTestsPresentationDemos.Requests;
using UnitTestsPresentationDemos.Responses;

namespace UnitTestsPresentationDemos.Implementation
{
	public class Repository : IRepository
	{
		public IEnumerable<Response> GetAll(Request request) => request.Text.Equals("Request Text")
			? Enumerable.Range(0, 100).Select(x => new Response())
			: Enumerable.Empty<Response>();
		public Response Save(Request request) => request.Text.Equals("Request Text")
			? new Response()
			: null;
	}
}
