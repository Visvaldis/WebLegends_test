using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebLegends_test.BLL.DTO
{
	public class FacilityLogDTO
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public int FacilityId { get; set; }
		[Required]
		public string FieldName { get; set; }
		[Required]
		public string OldValue { get; set; }
		[Required]
		public string NewValue { get; set; }
		[Required]
		public DateTime ChangeDate { get; set; }
	}
}
