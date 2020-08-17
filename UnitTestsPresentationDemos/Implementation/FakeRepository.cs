using System;
using System.Collections.Generic;
using System.Text;

using UnitTestsPresentationDemos.Abstraction;
using UnitTestsPresentationDemos.Requests;
using UnitTestsPresentationDemos.Responses;

namespace UnitTestsPresentationDemos.Implementation
{
	public class FakeRepository : IRepository
	{
		public IEnumerable<Response> GetAll(Request request) => new List<Response> { new FakeResponse() };
		public Response Save(Request request) => new FakeResponse();
	}
}
