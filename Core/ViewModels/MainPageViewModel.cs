using System.Threading.Tasks;

namespace Core
{
	public class MainPageViewModel : BaseViewModel
	{
		public MainPageViewModel () : this (new SampleService ())
		{
		}

		public MainPageViewModel (ISampleService sampleService)
		{
			_sampleService = sampleService;
			LoadDefaultMessageAsync ();
		}

		readonly ISampleService _sampleService;

		string _message;

		public string Message{ get { return _message; } set { ChangeAndNotify (ref _message, value); } }

		public async Task LoadDefaultMessageAsync ()
		{
			Message = await _sampleService.GetMessageAsync ();
		}
	}
}

