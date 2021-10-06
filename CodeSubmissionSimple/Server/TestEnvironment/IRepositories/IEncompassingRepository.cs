using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CodeSubmissionSimple.Server.TestEnvironment
{
    public interface IEncompassingRepository<T> where T : class
    {

        Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null);        

        Task<T> Get(Expression<Func<T, bool>> expression);

        Task Insert(T entity);

        Task Delete(int id);

        void Update(T entity);

        Task InsertRange(IEnumerable<T> entities);

    }
}
