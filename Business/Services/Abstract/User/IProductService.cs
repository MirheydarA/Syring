﻿using Business.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract.User
{
    public interface IProductService
    {
        Task<ProductIndexVM> IndexGetAllAsync(ProductIndexVM model);
    }
}
