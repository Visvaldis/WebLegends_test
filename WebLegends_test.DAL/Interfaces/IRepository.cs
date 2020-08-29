﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace WebLegends_test.DAL.Interfaces
{
	public interface IRepository<T> where T: class
	{
		IQueryable<T> GetAll();
		T Get(int id);
		IEnumerable<T> Find(Expression<Func<T, Boolean>> predicate);
		int Create(T item);
		void Update(T item);
		void Delete(int id);
	}
}
