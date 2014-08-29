/*
 * Source from https://github.com/aritchie/acr-xamarin-forms
 */

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

