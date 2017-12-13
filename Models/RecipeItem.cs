using System;
using SQLite;

namespace Tasty
{
	[Table("RecipesList")]
	public class RecipeItem
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }
		public bool Recommended { get; set; }
	}
}
