using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers_Hotel.Service
{
    public interface IService<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id );
        TEntity Create(TEntity entity );
        void Edit(int id , TEntity entity );
        void Delete(int id);

        TEntity Login(string User, string Password);
    }
}
