using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace Tasty
{
	public class SqliteService : ISqliteService
	{
		private static readonly AsyncLock Mutex = new AsyncLock();
		private SQLiteAsyncConnection _sqlCon;

		public SqliteService()
		{
			_sqlCon = DependencyService.Get<ISQLite>().GetConnection();

			CreateDatabaseAsync();
		}

		public async void CreateDatabaseAsync()
		{
			using (await Mutex.LockAsync().ConfigureAwait(false))
			{
				await _sqlCon.CreateTableAsync<RecipeItem>().ConfigureAwait(false);
			}
		}

		public async Task<IList<RecipeItem>> GetAll()
		{
			var items = new List<RecipeItem>();
			using (await Mutex.LockAsync().ConfigureAwait(false))
			{
				items = await _sqlCon.Table<RecipeItem>().ToListAsync().ConfigureAwait(false);
			}

			return items;
		}

		public async Task<IList<RecipeItem>> GetItems(string name)
		{
			List<RecipeItem> existingRecipeItems;
			using (await Mutex.LockAsync().ConfigureAwait(false))
			{
				existingRecipeItems = await _sqlCon.Table<RecipeItem>().Where(x => x.Name.ToUpper().Contains(name.ToUpper())).
				                                  ToListAsync().ConfigureAwait(false);

			}

			return existingRecipeItems;

		}

		public async Task Insert(RecipeItem item)
		{
			using (await Mutex.LockAsync().ConfigureAwait(false))
			{
				var existingTodoItem = await _sqlCon.Table<RecipeItem>()
						.Where(x => x.Id == item.Id)
						.FirstOrDefaultAsync();

				if (existingTodoItem == null)
				{
					await _sqlCon.InsertAsync(item).ConfigureAwait(false);
				}
				else
				{
					item.Id = existingTodoItem.Id;
					await _sqlCon.UpdateAsync(item).ConfigureAwait(false);
				}
			}
		}

		public async Task Remove(RecipeItem item)
		{
			await _sqlCon.DeleteAsync(item);
		}
	}
}
