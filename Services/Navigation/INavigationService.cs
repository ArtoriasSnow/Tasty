﻿using System;
namespace Tasty
{
	public interface INavigationService
	{
		void NavigateTo<TDestinationViewModel>(object navigationContext = null);

		void NavigateTo(Type destinationType, object navigationContext = null);

		void NavigateBack();
	}
}
