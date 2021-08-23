using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers_Hotel.Service
{
    public interface IServicePriceRooms<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int idRoom , int idSeason);
        void Create(TEntity entity);
        void Edit(int idRoom, int idSeason, TEntity entity);
        void Delete(int idRoom, int idSeason);
    }
}
