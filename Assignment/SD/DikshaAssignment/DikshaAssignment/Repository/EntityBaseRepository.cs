using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DikshaAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DikshaAssignment.Repository {
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class {
        public readonly EmployeeDBContext _dBContext;

        public EntityBaseRepository (EmployeeDBContext dBContext) {
            _dBContext = dBContext;
        }

        public IQueryable<T> GetAll () {
            return _dBContext.Set<T>().AsNoTracking().AsQueryable();
        }

        public T Get (int? id) {
            return _dBContext.Set<T>().Find(id);
        }

        public async Task Create (T entity) {
            await _dBContext.Set<T>().AddAsync(entity);
            SaveChanges();
        }

        public async Task Update (T entity) {
            _dBContext.Set<T> ().Update(entity);
             await _dBContext.SaveChangesAsync ();
            
        }

        public void Delete (T entity) {
            _dBContext.Set<T> ().Remove(entity);
            SaveChanges();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _dBContext.Set<T>().Where(expression).AsNoTracking();
        }
        
        public void SaveChanges(){
            _dBContext.SaveChangesAsync();
        }

    }
}