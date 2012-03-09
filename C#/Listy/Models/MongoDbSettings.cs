using System.Configuration;
using Norm;

namespace Listy.Models
{
	public class MongoDbSettings
	{
		public string Server { private get; set; }
		public int Port { private get; set; }
		public string Username { private get; set; }
		public string Password { private get; set; }
		public string Database { private get; set; }
		private string Query { get; set; }

		public string ConnectionString
		{
			get
			{
				var authentication = string.Empty;
				if (Username != null)
				{
					authentication = string.Concat(Username, ':', Password, '@');
				}
				if (!string.IsNullOrEmpty(Query) && !Query.StartsWith("?"))
				{
					Query = string.Concat('?', Query);
				}
				return string.Format("mongodb://{0}{1}:{2}/{3}{4}", authentication, Server, Port, Database, Query);
			}
		}

		public static IMongo GetDataBase()
		{
			var connection = new MongoDbSettings
			{
				Server = ConfigurationManager.AppSettings["mongo.server"],
				Port = int.Parse(ConfigurationManager.AppSettings["mongo.port"]),
				Username = ConfigurationManager.AppSettings["mongo.username"],
				Password = ConfigurationManager.AppSettings["mongo.password"],
				Database = ConfigurationManager.AppSettings["mongo.databasename"]
			};

			return Mongo.Create(connection.ConnectionString);
		}
	}
}