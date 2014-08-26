using System;
using Core.Helpers.Extensions;
using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Helpers.Autofac
{
	public class PageLocator : IPageLocator
	{

		protected virtual Page CreatePage (Type pageType)
		{
			return Activator.CreateInstance (pageType) as Page;
		}


		protected virtual IViewModel CreateViewModel (Type viewModelType)
		{
			return Activator.CreateInstance (viewModelType) as IViewModel;
		}


		protected virtual Type FindPageForViewModel (Type viewModelType)
		{
			var pageTypeName = viewModelType
				.AssemblyQualifiedName
				.Replace ("ViewModel", "View");

			var pageType = Type.GetType (pageTypeName);
			if (pageType == null)
				throw new ArgumentException (pageTypeName + " type not exist");

			return pageType;
		}


		public Page ResolvePageAndViewModel (Type viewModelType, object args)
		{
			var viewModel = this.CreateViewModel (viewModelType);
			viewModel.Init (args);
			return this.ResolvePage (viewModel);
		}


		public Page ResolvePage (IViewModel viewModel)
		{
			var pageType = this.FindPageForViewModel (viewModel.GetType ());
			var page = this.CreatePage (pageType);
			page.BindViewModel (viewModel);
			return page;
		}
	}
}

