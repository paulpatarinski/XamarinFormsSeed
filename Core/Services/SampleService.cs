using System;
using System.Threading.Tasks;

namespace Core
{
	public interface ISampleService
	{
		Task<string> GetMessageAsync ();
	}

	public class SampleService : ISampleService
	{
		public async Task<string> GetMessageAsync ()
		{
			return "Hello from the Sample Service.";
		}
	}
}

