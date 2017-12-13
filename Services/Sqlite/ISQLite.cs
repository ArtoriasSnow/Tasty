using System;
using SQLite;

namespace Tasty
{
	public interface ISQLite
	{
		SQLiteAsyncConnection GetConnection();
	}
}
