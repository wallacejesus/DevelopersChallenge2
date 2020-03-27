using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using NIBO.Challenge.Infra.DataBaseContext;
using NIBO.Challenge.Infra.Interface;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace NIBO.Challenge.Infra.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public SqlServerContext _context;

        public Repository(IConfiguration Configuration)
        {
            this._context = new SqlServerContext(Configuration);
        }
        public Repository()
        {
    
        }
        public Repository(object configuration1, object configuration2)
        {
        }

        public int? Insert(TEntity entity,  int? timeout = null)
        {
            return entity == null ? null : _context.Connection.Insert(entity, _context._transaction, timeout);
        }

        public void Update(TEntity entity,  int? timeout = null)
        {
            _context.Connection.Update(entity, _context._transaction, timeout);
        }
        public void Delete(TEntity entity,  int? timeout = null)
        {
            _context.Connection.Delete(entity,_context._transaction, timeout);
        }
        public IEnumerable<TEntity> GetList(object @where = null, int? timeout = null)
        {
            return _context.Connection.GetList<TEntity>(@where, _context._transaction);
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            _context.BeginTransaction(isolationLevel);
        }
        public void Commit()
        {
            if(_context._transaction!=null)
               _context.Commit();
        }
        public void Rollback()
        {
            if (_context._transaction != null)
                _context.Rollback();
        }
    }
}
