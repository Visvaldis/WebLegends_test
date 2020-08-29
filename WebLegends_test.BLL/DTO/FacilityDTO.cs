﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebLegends_test.BLL.DTO
{
	public class FacilityDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Phone_Number { get; set; }
		public string Email { get; set; }
		public FacilityStatusDTO Status { get; set; }
	}
}