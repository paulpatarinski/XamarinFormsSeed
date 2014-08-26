using System.Threading.Tasks;

namespace Core.Services
{
  public interface ISampleService
  {
    Task<string> GetMessageAsync ();
  }
}