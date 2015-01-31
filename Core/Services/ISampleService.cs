using System.Threading.Tasks;
using Core.Models;

namespace Core.Services
{
  public interface ISampleService
  {
    Task<SampleModel> LoadMessageAsync ();
  }
}