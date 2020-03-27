using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using NIBO.Challenge.Infra.DataBaseContext;
using NIBO.Challenge.Infra.Repository;
using NIBO.Challenge.Service.Interface;
using System.Linq;

namespace NIBO.Challenge.Service.Service
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        public Repository<TEntity> repository;

        public Service(IConfiguration Configuration,SqlServerContext context=null)
        {
 
            if (context == null)
            {
                repository = new Repository<TEntity>(Configuration);
                return;
            }
            repository = new Repository<TEntity>();
            repository._context = context;

      
            
        }
        public int? Insert(TEntity entity)
        {
            
            return repository.Insert(entity);
        }

        public IEnumerable<TEntity> GetList(object @where=null)
        {
            return repository.GetList(@where);
        }
    }
}
