using System.ComponentModel;

namespace Core.ViewModels
{
	public interface IViewModel : INotifyPropertyChanged
	{
		void Init (object args);

		void OnAppearing ();

		void OnDisappearing ();
	}
}

