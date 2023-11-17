﻿using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract.Admin
{
    public interface IAccountRepository
    {
        public Task<bool> HasAccessToAdminPanelAsync(Common.Entities.User user);
    }
}
