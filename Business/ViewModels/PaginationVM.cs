﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels
{
    public class PaginationVM
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 2;
    }
}
