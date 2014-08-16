using System;
using Xamarin.Forms;

namespace Core
{
	public class MainPage : ContentPage
	{
		public MainPage ()
		{
			Content = new Label {
				Text = "Change this page.",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};
		}
	}
}

