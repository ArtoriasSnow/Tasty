using System;
using Unity;

namespace Tasty
{
	public class ViewModelLocator
	{
		readonly IUnityContainer _container;

		public ViewModelLocator()
		{
			_container = new UnityContainer();

			// ViewModels
			_container.RegisterType<RecipesListViewModel>();
			_container.RegisterType<RecipeItemViewModel>();

			// Services     
			_container.RegisterType<INavigationService, NavigationService>();
			_container.RegisterType<ISqliteService, SqliteService>();
		}

		public RecipesListViewModel RecipesListViewModel
		{
			get { return _container.Resolve<RecipesListViewModel>(); }
		}

		public RecipeItemViewModel RecipeItemViewModel
		{
			get { return _container.Resolve<RecipeItemViewModel>(); }
		} 
	}
}
