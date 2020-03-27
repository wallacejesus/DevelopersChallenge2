using System;
using System.Collections.Generic;
using System.Text;
using NIBO.Challenge.Infra.Repository;
using NIBO.Challenge.Servico.Interface;

namespace NIBO.Challenge.Servico.Service
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        Repository<TEntity> repository;

        public Service()
        {
            repository = new Repository<TEntity>();
        }
        public int? Insert(TEntity entity, int? timeout = null)
        {
            return repository.Insert(entity,timeout);
        }

        public void Delete(TEntity entity, int? timeout = null)
        {
            repository.Delete(entity,timeout);
        }

        public void Update(TEntity entity, int? timeout = null)
        {
            repository.Update(entity, timeout);
        }

        public IEnumerable<TEntity> Get()
        {
            throw new NotImplementedException();
        }

        public TEntity GetBy(object where)
        {
            throw new NotImplementedException();
        }


    }
}
