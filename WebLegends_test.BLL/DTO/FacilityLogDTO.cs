using System;
using System.Collections.Generic;
using System.Text;

namespace WebLegends_test.BLL.DTO
{
	public class FacilityLogDTO
	{
		public int Id { get; set; }
		public FacilityDTO Facility { get; set; }
		public string FieldName { get; set; }
		public string OldValue { get; set; }
		public string NewValue { get; set; }
		public DateTime ChangeDate { get; set; }
	}
}
