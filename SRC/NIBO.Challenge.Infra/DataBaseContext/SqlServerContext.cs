using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace NIBO.Challenge.Infra.DataBaseContext
{
    public class SqlServerContext
    {
        private readonly string _connectionString;

        private IDbConnection _connection;

        public IDbTransaction _transaction { get; private set; }

        //private IConfiguration Configuration { get; }

        public SqlServerContext(IConfiguration Configuration)
        {
    
            _connectionString = Configuration.GetSection("SqlServerConfig:ConnectionString").Value;
        }

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);

                }

                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                return _connection;
            }
        }

        public IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot)
        {
            if (_transaction == null)
                _transaction = Connection.BeginTransaction(isolationLevel);

            return _transaction;
        }

        public void Commit()
        {
            if (_connection.State != ConnectionState.Broken && _connection.State != ConnectionState.Closed)
            {
                if (_transaction != null)
                {
                    _transaction.Commit();
                    _transaction.Dispose();
                    _transaction = null;
                    _connection.Close();
                }
            }
            
        }

        public void Rollback()
        {
            if (_connection.State != ConnectionState.Broken && _connection.State != ConnectionState.Closed)
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                    _transaction.Dispose();
                    _transaction = null;
                    _connection.Close();
                }
            }
        }
    }
}
