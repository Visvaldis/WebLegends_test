
using System;
using System.Collections.Generic;
using System.Text;

namespace WebLegends_test.DAL.Entities
{
	public class FacilityLog
	{
		public int Id { get; set; }
		public int FacilityId { get; set; }
		public string FieldName { get; set; }
		public string OldValue { get; set; }
		public string NewValue { get; set; }
		public DateTime ChangeDate { get; set; }
	}
}
