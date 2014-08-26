using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Helpers.Extensions
{
	public static class PageExtensions
	{
		public static void BindViewModel (this Page page, IViewModel viewModel)
		{
			page.BindingContext = viewModel;

			page.Appearing += (sender, args1) => viewModel.OnAppearing ();
			page.Disappearing += (sender, args1) => viewModel.OnDisappearing ();             
		}
	}
}

