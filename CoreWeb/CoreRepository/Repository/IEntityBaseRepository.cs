using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRepository.Repository
{
    public interface IEntityBaseRepository <T>
    {
        IQueryable<T> GetAll();
        T Get(int id);
        Task Create(T entity);
        Task Update(T entity);
        Task Edit(T oldEntity, T newEntity);
        void Delete(T entity);
    }
}
