using MySql.Data.MySqlClient;

namespace Lawyer_calendar
{
	internal static class SqlConnector
	{
		private static MySqlConnection connector = null;
		public static MySqlConnection Connector { get; }

		public static void SqlConnect()
		{
			string conn_str = "server=10.116.158.41; Database=mysql; port=3306; uid=mysql; pwd=\'mysql\'";

			if (connector == null)
			{
				connector = new MySqlConnection(conn_str);           //подключение с помощью stringbuilder
				connector.Open();
			}
		}

		public static bool SqlOperation(string commandString)
		{
			MySqlCommand mySqlCommand = new MySqlCommand(commandString, connector);
			return mySqlCommand.ExecuteNonQuery() > 0;
		}
	}
}
