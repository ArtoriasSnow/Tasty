using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Tasty
{
	public class RecipeItemViewModel : ViewModelBase
	{
		private RecipeItem _item;

		private ICommand _saveCommand;
		private ICommand _deleteCommand;

		private INavigationService _navigationService;
		private ISqliteService _sqliteService;

		public RecipeItemViewModel(
			INavigationService navigationService,
			ISqliteService sqliteService)
		{
			_navigationService = navigationService;
			_sqliteService = sqliteService;
		}

		private bool _state;
		public bool State
		{
			get { return _state; }
			set { 
				_state = value; 
                RaisePropertyChanged();
			 } 
		}

		public RecipeItem Item
		{
			get { return _item; }
			set
			{
				_item = value;
				RaisePropertyChanged();
			}
		}

		public ICommand SaveCommand
		{
			get { return _saveCommand = _saveCommand ?? new DelegateCommand(SaveCommandExecute); }
		}

		public ICommand DeleteCommand
		{
			get { return _deleteCommand = _deleteCommand ?? new DelegateCommand(DeleteCommandExecute); }
		}

		public override void OnAppearing(object navigationContext)
		{
			var recipeItem = navigationContext as RecipeItem;

			if (recipeItem != null)
			{
				Item = recipeItem;


			}


			if (string.IsNullOrEmpty(recipeItem.Name))
			{
				State = false;
			}
			else 
			{
				State = true;
			}

			base.OnAppearing(navigationContext);
		}


		private async void SaveCommandExecute()
		{
			await _sqliteService.Insert(Item);
			_navigationService.NavigateBack();
		}

		private async void DeleteCommandExecute()
		{
			await _sqliteService.Remove(Item);
			_navigationService.NavigateBack();
		}

	}
}
