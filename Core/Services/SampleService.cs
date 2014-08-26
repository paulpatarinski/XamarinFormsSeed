using System.Threading.Tasks;

namespace Core.Services
{
  public class SampleService : ISampleService
	{
		public async Task<string> GetMessageAsync ()
		{
			return "Hello from the Sample Service.";
		}
	}
}

