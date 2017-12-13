using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tasty
{
	public interface ISqliteService
	{
		Task<IList<RecipeItem>> GetAll();
		Task Insert(RecipeItem item);
		Task Remove(RecipeItem item);
		Task <IList<RecipeItem>> GetItems(string name);
	}
}
