using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CodeSubmissionSimple.Server.TestEnvironment
{
    public class EncompassingRepository<T> : IEncompassingRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _db;

        public EncompassingRepository(AppDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();

        }


        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null)
        {
            IQueryable<T> query = _db;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            return await query.AsNoTracking().ToListAsync();

        }


        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = _db;

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }


        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }


        public async Task Delete(int id)
        {

            var entity = await _db.FindAsync(id);
            _db.Remove(entity);

        }


        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
             _db.RemoveRange(entities);
        }


    }
}
