using System;
using System.Collections.Generic;
using System.Text;

namespace NIBO.Challenge.Service.Interface
{
    public interface IService<TEntity>
    {
        int? Insert(TEntity entity);
    }
}
