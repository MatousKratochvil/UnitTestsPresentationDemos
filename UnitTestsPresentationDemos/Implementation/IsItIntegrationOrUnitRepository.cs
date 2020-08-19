
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

using UnitTestsPresentationDemos.Abstraction;
using UnitTestsPresentationDemos.Requests;
using UnitTestsPresentationDemos.Responses;

namespace UnitTestsPresentationDemos.Implementation
{
	public class IsItIntegrationOrUnitRepository : IRepositoryAsync
	{
		private static string PathToFile() => Path.Combine(Directory.GetCurrentDirectory(), "DB.txt");

		public async Task<IEnumerable<Response>> GetAllAsync(Request request)
			=>
				(await File.ReadAllLinesAsync(PathToFile()))
				.Select(x => new Response { Text = x });
		public async Task<Response> SaveAsync(Request request)
			=>
				(await SaveFileAsync(request))
				.Select(x => new Response { Text = x.ToString() })
				.FirstOrDefault();

		private static async Task<IEnumerable<bool>> SaveFileAsync(Request request)
		{
			await File.AppendAllLinesAsync(PathToFile(), new string[] { request.Text });
			return new bool[] { true };
		}
	}
}
