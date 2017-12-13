using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Tasty
{
	public partial class RecipeItemView : ContentPage
	{
		private object Parameter { get; set; }

		public RecipeItemView(object parameter)
		{
			InitializeComponent();

			Parameter = parameter;

			BindingContext = App.Locator.RecipeItemViewModel;
		}

		protected override void OnAppearing()
		{
			var viewModel = BindingContext as RecipeItemViewModel;
			if (viewModel != null) viewModel.OnAppearing(Parameter);
		}

		protected override void OnDisappearing()
		{
			var viewModel = BindingContext as RecipeItemViewModel;
			if (viewModel != null) viewModel.OnDisappearing();
		}
	}
}
