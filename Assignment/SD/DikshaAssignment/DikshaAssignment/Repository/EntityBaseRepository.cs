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

        /// <summary>
        /// Default COnstructor
        /// </summary>
        /// <param name="dBContext">dBContext</param>
        public EntityBaseRepository (EmployeeDBContext dBContext) {
            _dBContext = dBContext;
        }


        /// <summary>
        /// This method is used to get the all records from the db.
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll () {
            return _dBContext.Set<T>().AsNoTracking().AsQueryable();
        }

        /// <summary>
        /// This method is used to get the single record using id.
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public T Get (int? id) {
            return _dBContext.Set<T>().Find(id);
        }

        /// <summary>
        /// To method is used to insert the record into the db.
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns></returns>
        public async Task Create (T entity) {
            await _dBContext.Set<T>().AddAsync(entity);
            SaveChanges();
        }

        /// <summary>
        /// This method is used to update the existing record in the db.
        /// </summary>
        /// <param name="entity">entity`</param>
        /// <returns></returns>
        public async Task Update (T entity) {
            _dBContext.Set<T> ().Update(entity);
             await _dBContext.SaveChangesAsync ();
            
        }

        /// <summary>
        /// This method is used to remove the record from the db.
        /// </summary>
        /// <param name="entity">entity</param>
        public void Delete (T entity) {
            _dBContext.Set<T> ().Remove(entity);
            SaveChanges();
        }

        /// <summary>
        /// This method is used to find the record by using conditions.
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns></returns>
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _dBContext.Set<T>().Where(expression).AsNoTracking();
        }
        
        /// <summary>
        /// This method is used to save the changes into db.
        /// </summary>
        public void SaveChanges(){
            _dBContext.SaveChangesAsync();
        }

    }
}