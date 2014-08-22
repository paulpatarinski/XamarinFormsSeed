using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Core
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
			BindingContext = new MainPageViewModel ();
		}
	}
}

