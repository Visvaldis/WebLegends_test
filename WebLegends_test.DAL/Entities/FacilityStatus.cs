
using System;
using System.Collections.Generic;
using System.Text;

namespace WebLegends_test.DAL.Entities
{
	public class FacilityStatus
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public override bool Equals(object obj)
		{
			return this.ToString().Equals(obj.ToString());
		}

		public override string ToString()
		{
			return Name;
		}
	}

}
