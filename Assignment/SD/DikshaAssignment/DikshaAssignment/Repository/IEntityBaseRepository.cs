using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DikshaAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DikshaAssignment.Repository {
    
    public interface IEntityBaseRepository<T> {
     
        /// <summary>
        /// This method is used to get all records.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll ();

        /// <summary>
        /// This  method is used to get the record by using id.
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        T Get (int ? id);

        /// <summary>
        /// This method is used to insert the new record into collection.
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns></returns>
        Task Create (T entity);

        /// <summary>
        /// This method is used to update the exixting record.
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns></returns>
        Task Update (T entity);

        /// <summary>
        /// This method is used to delete the record.
        /// </summary>
        /// <param name="entity">entity</param>
        void Delete (T entity);

        /// <summary>
        /// To find the data by expression
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns></returns>
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        /// <summary>
        /// To save the changes into db.
        /// </summary>
        void SaveChanges();
    }
}