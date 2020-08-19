using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using UnitTestsPresentationDemos.Requests;
using UnitTestsPresentationDemos.Responses;

namespace UnitTestsPresentationDemos.Abstraction
{
	public interface IRepositoryAsync
	{
		Task<Response> SaveAsync(Request request);

		Task<IEnumerable<Response>> GetAllAsync(Request request);
	}
}
