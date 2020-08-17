﻿
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

		public Response Save(Request request) => repository.Save(request);

		public int Addition(int x, int y) => x + y;
	}
}