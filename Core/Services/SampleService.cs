using System;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Services
{
  public class SampleService : ISampleService
  {
    public async Task<SampleModel> LoadMessageAsync()
    {
      var sampleModel = new SampleModel();

      //TODO: Do long task here (HTTP call)
      await Task.Delay(TimeSpan.FromSeconds(2));

      sampleModel.Message = "Hello from the Sample Service.";

      return sampleModel;
    }
  }
}