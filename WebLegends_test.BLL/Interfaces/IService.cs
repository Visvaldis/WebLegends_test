using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebLegends_test.BLL.Interfaces
{
	public interface IService<T> where T : class
	{
		Task<ICollection<T>> GetAll();
		Task<T> Get(int id);
		Task<int> Create(T item);
		Task Update(T item);
		Task Delete(int id);
		Task<bool> Exist(int id);
		void Dispose();
	}
}
