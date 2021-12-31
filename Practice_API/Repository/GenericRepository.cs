using Microsoft.EntityFrameworkCore;
using Practice_API.Data;
using Practice_API.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Practice_API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext context;
        private readonly DbSet<T> db;
        public GenericRepository(AppDbContext context)
        {
            this.context = context;

            db = this.context.Set<T>();
        }
        public async Task Delete(int id)
        {
            var entity = await db.FindAsync(id);
            db.Remove(entity);
            //throw new NotImplementedException();
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null)
        {
            IQueryable<T> query = db;
            if(expression != null)
            {
                query = query.Where(expression);
            }

            return await query.AsNoTracking().ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<T> GetT(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = db;

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
            //throw new NotImplementedException();
        }

        public async Task Insert(T entity)
        {
            await db.AddAsync(entity);
            //throw new NotImplementedException();
        }

        public void  Update(T entity)
        {
            db.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            
        }
    }
}
