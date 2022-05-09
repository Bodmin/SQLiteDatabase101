using Dapper;
using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SQLite_List
{
	public class SqliteDataAccess
	{
		public static List<Sites> LoadSites()
		{
			using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
			{

				var output = cnn.Query<Sites>("select * from Sites", new DynamicParameters());
				return output.AsList();
				// if necessary, change the ToList() to AsList()
			}
		}

		public static void SaveSite(Sites siteItem)
		{
			using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
			{
				cnn.Execute("insert into Sites (labelName, category, site, username, pass, notes) (@labelName, @category, @site, @username, @pass, @notes)", siteItem);
			}
		}

		public static void DeleteSite(Sites siteItem)
		{
			using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
			{
				cnn.Execute("delete from Sites where site = '" + siteItem.site + "'");
			}
		}

		private static string LoadConnectionString(string id = "Default")
		{
			return ConfigurationManager.ConnectionStrings[id].ConnectionString;
		}
	}
}
