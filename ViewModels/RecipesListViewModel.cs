using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Tasty
{

	public class RecipesListViewModel : ViewModelBase
	{
		private ObservableCollection<RecipeItem> _items;
		private RecipeItem _selectedItem;
		private string _searchText;


		private ICommand _addCommand;


		private INavigationService _navigationService;
		private ISqliteService _sqliteService;

		public RecipesListViewModel(
			INavigationService navigationService,
			ISqliteService sqliteService)
		{
			_navigationService = navigationService;
			_sqliteService = sqliteService;
		}



		public ObservableCollection<RecipeItem> Items
		{
			get { return _items; }
			set
			{
				_items = value;
				RaisePropertyChanged();
			}
		}


		public RecipeItem SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				_selectedItem = value;
				_navigationService.NavigateTo<RecipeItemViewModel>(_selectedItem);
			}
		}

		public string SearchText
		{
			get { return _searchText; }
			set
			{
				_searchText = value;
				FilterRecipes();
			}
		}


		private async void FilterRecipes()
		{

			if (_items != null)
			{
				if (String.IsNullOrEmpty(_searchText))
				{
					RefreshAllItems();
				}
				else
				{
					var queryResult = await _sqliteService.GetItems(_searchText);


					Items = new ObservableCollection<RecipeItem>();
					foreach (var item in queryResult)
					{
						Items.Add(item);
					}
				}
			}
		}


		public ICommand AddCommand
		{
			get { return _addCommand = _addCommand ?? new DelegateCommand(AddCommandExecute); }
		}

		public override async void OnAppearing(object navigationContext)
		{
			base.OnAppearing(navigationContext);
			RefreshAllItems();


		}

		private void AddCommandExecute()
		{
			var recipeItem = new RecipeItem();
			_navigationService.NavigateTo<RecipeItemViewModel>(recipeItem);

		}

		private async void RefreshAllItems()
		{
			var result = await _sqliteService.GetAll();

			Items = new ObservableCollection<RecipeItem>();
			foreach (var item in result)
			{
				Items.Add(item);
			}
		}


	}
}
