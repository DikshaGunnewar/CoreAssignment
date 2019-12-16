using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DikshaAssignment.Models;

namespace DikshaAssignment.Repository {
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class {
        public readonly EmployeeDBContext _dBContext;

        public EntityBaseRepository (EmployeeDBContext dBContext) {
            _dBContext = _dBContext;
        }

        public IQueryable<T> GetAll () {
            return _dBContext.Set<T> ();
        }

        public T Get (int id) {
            return _dBContext.Set<T> ().Find (id);
        }

        public async Task Create (T entity) {
            await _dBContext.Set<T> ().AddAsync (entity);
        }

        public async Task Update (T entity) {
            _dBContext.Set<T> ().Update (entity);
            await _dBContext.SaveChangesAsync ();

        }

        public async void Delete (T entity) {
            _dBContext.Set<T> ().Remove (entity);
            await _dBContext.SaveChangesAsync ();
        }
    }
}