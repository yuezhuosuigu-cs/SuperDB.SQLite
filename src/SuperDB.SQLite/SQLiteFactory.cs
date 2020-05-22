
using Microsoft.Data.Sqlite;

using SuperDB.Config;

using System.Data;

namespace SuperDB.MySQL
{
    public class SQLiteFactory : DBFactory
    {
        private IDbConnection _Connection;

        public static SQLiteFactory Create()
        {
            return new SQLiteFactory();
        }

        public override IDbConnection Connection
        {
            get
            {
                if (_Connection == default)
                {
                    _Connection = new SqliteConnection(DBConfig.ConnectionString);
                }
                if (_Connection.State != ConnectionState.Open)
                {
                    _Connection.Open();
                }
                return _Connection;
            }
        }
    }
}
