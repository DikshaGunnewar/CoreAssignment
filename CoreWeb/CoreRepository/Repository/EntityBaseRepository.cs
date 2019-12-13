using CoreDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreRepository.Repository
{
    public abstract class EntityBaseRepository <T> : IEntityBaseRepository<T> where T : class
    {
        public readonly DBContext _dBContext;

        // Default Constructor
        public EntityBaseRepository(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IQueryable<T> GetAll()
        {
            return _dBContext.Set<T>();
        }
        public async Task Create(T entity)
        {
            await _dBContext.Set<T>().AddAsync(entity);
        }

        public async Task Update(T entity)
        {
            _dBContext.Set<T>().Update(entity);
            await _dBContext.SaveChangesAsync();
          
        }
        public async Task Edit (T oldEntity, T newEntity)
        {
            _dBContext.Entry(oldEntity).CurrentValues.SetValues(newEntity);
            await _dBContext.SaveChangesAsync();
        }

        public async void Delete(T entity)
        {
             _dBContext.Set<T>().Remove(entity);
            await _dBContext.SaveChangesAsync();
        }

        public T Get(long id)
        {
            return _dBContext.Set<T>().Find(id);
        }

    }
}
