/*
 * Source from https://github.com/aritchie/acr-xamarin-forms
 */

using System;
using Autofac;
using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Helpers.Autofac
{
  public class AutofacPageLocator : PageLocator
  {
    private readonly ILifetimeScope container;

    public AutofacPageLocator(ILifetimeScope container)
    {
      this.container = container;
    }

    protected override Page CreatePage(Type pageType)
    {
      return this.container.Resolve(pageType) as Page;
    }

    protected override IViewModel CreateViewModel(Type viewModelType)
    {
      return this.container.Resolve(viewModelType) as IViewModel;
    }
  }
}