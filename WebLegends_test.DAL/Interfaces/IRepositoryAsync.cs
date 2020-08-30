using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebLegends_test.DAL.Interfaces
{
	public interface IRepositoryAsync<TEntity, TKey> where TEntity : class
	{
		Task<IEnumerable<TEntity>> GetAll();
		Task<TEntity> Get(TKey id);
		Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate);
		Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
		Task<TKey> Create(TEntity item);
		Task Update(TEntity item);
		Task Delete(TKey id);
	}
}
