using System;
using System.Collections.Generic;
using System.Text;

namespace WebLegends_test.BLL.Interfaces
{
	public interface IService<T> where T : class
	{
		ICollection<T> GetAll();
		T Get(int id);
		int Add(T item);
		void Update(T item);
		void Delete(int id);
		bool Exist(int id);
		void Dispose();
	}
}
