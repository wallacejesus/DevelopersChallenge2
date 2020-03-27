using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace NIBO.Challenge.Infra.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void BeginTransaction(IsolationLevel isolationLevel);
        void Commit();
        void Rollback();
        int? Insert(TEntity entidade, int? timeout = null);
        void Update(TEntity entidade, int? timeout = null);
        void Delete(TEntity entidade, int? timeout = null);
    }
}
