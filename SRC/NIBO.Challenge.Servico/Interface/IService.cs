using System;
using System.Collections.Generic;
using System.Text;

namespace NIBO.Challenge.Servico.Interface
{
    public interface IService<TEntity>
    {
        int? Insert(TEntity entity, int? timeout = null);
        void Delete(TEntity entity, int? timeout = null);
        void Update(TEntity entity, int? timeout = null);
        IEnumerable<TEntity> Get();
        TEntity GetBy(object where);


    }
}
