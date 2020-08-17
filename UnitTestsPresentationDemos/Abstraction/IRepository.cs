using System;
using System.Collections.Generic;
using System.Text;

using UnitTestsPresentationDemos.Requests;
using UnitTestsPresentationDemos.Responses;

namespace UnitTestsPresentationDemos.Abstraction
{
	public interface IRepository
	{
		Response Save(Request request);

		IEnumerable<Response> GetAll(Request request);
	}
}
