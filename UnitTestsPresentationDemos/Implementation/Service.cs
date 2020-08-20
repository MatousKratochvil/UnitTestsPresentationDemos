
using System;
using System.Collections.Generic;

using UnitTestsPresentationDemos.Abstraction;
using UnitTestsPresentationDemos.Requests;
using UnitTestsPresentationDemos.Responses;

namespace UnitTestsPresentationDemos.Implementation
{
	public class Service : IService
	{
		private readonly IRepository repository;

		public Service(IRepository repository)
		{
			this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
		}
		public Service()
		{

		}

		public IEnumerable<Response> GetAll(Request request) => repository.GetAll(request);

		public IEnumerable<Response> GetAllRepositoryNotCalled(Request request) => new List<Response> { new FakeResponse() };

		public Response Save(Request request) => repository.Save(request);

		public int AddNonNegativeNumbers(int x, int y)
		{
			if (x < 0 || y < 0)
				throw new InvalidOperationException("EXCEPTION");
			return x + y;
		}
	}
}
