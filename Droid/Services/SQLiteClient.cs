
using System.IO;
using SQLite;
using Tasty.Droid;
using Xamarin.Forms;


[assembly: Dependency(typeof(SQLiteClient))]
namespace Tasty.Droid
{
	public class SQLiteClient : ISQLite
	{
		public SQLiteAsyncConnection GetConnection()
		{
			string sqliteFilename = "RecipesList.db3";
			string documentsPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), 
			                                    sqliteFilename);
			
            return new SQLiteAsyncConnection(documentsPath);


		}
	}
}
