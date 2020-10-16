using System;
using System.Linq;


namespace StoreWarehouse.Core.Interfaces
{
    public interface IRepository<T> 
    {
        IQueryable<T> GetAll();

        T Get(Guid id);

        void Update(T @newV);

        void Add(T item);

        void Remove(T item);

        bool CheckName(T item);
    }
}
