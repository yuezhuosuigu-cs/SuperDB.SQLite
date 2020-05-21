
using Microsoft.Data.Sqlite;

using SuperDB.Config;

using System.Data;

namespace SuperDB.MySQL
{
    public class SQLiteFactory : IDBFactory
    {
        private IDbConnection _Connection;
        private IDbTransaction _Transaction;

        public static SQLiteFactory Create()
        {
            return new SQLiteFactory();
        }

        public IDbConnection Connection
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

        public IDbTransaction Transaction
        {
            get
            {
                if (_Transaction == default)
                {
                    _Transaction = Connection.BeginTransaction();
                }
                return _Transaction;
            }
        }

        public bool Commit()
        {
            Transaction.Commit();
            return true;
        }

        public void Dispose()
        {
            _Connection?.Dispose();
            _Connection = default;
            _Transaction = default;
        }

        public bool Rollback()
        {
            Transaction.Rollback();
            return false;
        }
    }
}
