﻿using Xamarin.Forms;

namespace Tasty
{
	public partial class App : Application
	{
		private static ViewModelLocator _locator;

		public static ViewModelLocator Locator
		{
			get { return _locator = _locator ?? new ViewModelLocator(); }
		}

		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new RecipesListView(null));
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
