using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebLegends_test.DAL.Context;
using WebLegends_test.DAL.Interfaces;

namespace WebLegends_test.DAL.Repositories
{
    public abstract class BaseRepositoryAsync<TEntity, TKey> : IRepositoryAsync<TEntity, TKey>
       where TEntity : class
    {
        private readonly DbSet<TEntity> set;
        protected readonly EfContext db;
       public BaseRepositoryAsync(EfContext context)
        {
            set = context.Set<TEntity>();
            db = context;
        }

        public abstract Task<TKey> Create(TEntity item);

        public async Task Delete(TKey id)
        {
            var item = await set.FindAsync(id);
            if (item != null)
            {
                set.Remove(item);
            }
        }

        public async Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAllQuary().Where(predicate).ToListAsync();
        }


		public virtual async Task<TEntity> Get(TKey id)
        {
			return await set.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await GetAllQuary().ToListAsync();
        }

        public virtual Task Update(TEntity item)
        {
            set.Update(item);
            return Task.CompletedTask;
        }

		public async Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
		{
            return await GetAllQuary().FirstOrDefaultAsync(predicate);
        }
        public virtual IQueryable<TEntity> GetAllQuary()
		{
            return set;
		}

	}
}
