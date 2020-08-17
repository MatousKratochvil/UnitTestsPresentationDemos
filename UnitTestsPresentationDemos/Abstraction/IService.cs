using System.Collections.Generic;

using UnitTestsPresentationDemos.Requests;
using UnitTestsPresentationDemos.Responses;

namespace UnitTestsPresentationDemos.Abstraction
{
	public interface IService
	{
		Response Save(Request request);

		IEnumerable<Response> GetAll(Request request);
	}
}
