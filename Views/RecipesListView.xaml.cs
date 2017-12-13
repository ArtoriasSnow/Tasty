using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace Tasty
{
	public partial class RecipesListView : ContentPage
	{
		private object Parameter { get; set; }
		public RecipesListView(object parameter)
		{
			InitializeComponent();
			Parameter = parameter;
			BindingContext = App.Locator.RecipesListViewModel;

		}



		protected override void OnAppearing()
		{
			var viewModel = BindingContext as RecipesListViewModel;
			if (viewModel != null) viewModel.OnAppearing(Parameter);
		}

		protected override void OnDisappearing()
		{
			var viewModel = BindingContext as RecipesListViewModel;
			if (viewModel != null) viewModel.OnDisappearing();
		}
	}
}
