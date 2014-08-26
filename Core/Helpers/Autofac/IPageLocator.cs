using System;
using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Helpers.Autofac
{
	public interface IPageLocator
	{
		Page ResolvePageAndViewModel (Type viewModelType, object args = null);

		Page ResolvePage (IViewModel viewModel);
	}
}

