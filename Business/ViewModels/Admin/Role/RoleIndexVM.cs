﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels.Admin.Role
{
	public class RoleIndexVM
	{
		public List<IdentityRole> Roles { get; set; }
	}
}
