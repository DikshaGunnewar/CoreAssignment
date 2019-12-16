using System.Collections.Generic;
using System.Threading.Tasks;
using DikshaAssignment.Models;
using System.Collections.Generic;
using System.Linq;

namespace DikshaAssignment.Repository
{
    public interface IEntityBaseRepository<T>
    {
        //  List<T> GetEmployees();
         IQueryable<T> GetAll();
         T Get(int id);
         Task Create(T entity);
         Task Update(T entity);
         void Delete(T entity);
    }
}