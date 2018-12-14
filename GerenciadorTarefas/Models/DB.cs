using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace GerenciadorTarefas.Models.DAO
{
    class DB
    {
        private static DbConnection _db;

        private DB() {  }

        private static DbConnection GetConnectionn()
        {
            String connectionString = @"Server=.\SQLEXPRESS;Database=GerenciadorTarefas;User Id=root;Password=toor;";
            using (_db = new SqlConnection(connectionString))
            {
                if (_db.State != System.Data.ConnectionState.Open)
                {
                    _db = new SqlConnection(connectionString);
                    _db.Open();
                }
            }
            return _db;
        }

        public static DbCommand GetCommand()
        {
            DbCommand comando = GetConnectionn().CreateCommand();

            return comando;
        }
    }
}