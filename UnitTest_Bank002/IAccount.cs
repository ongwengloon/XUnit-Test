﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Bank002
{
    public interface IAccount
    {
        List<IAccount> GetAccounts();
        IAccount GetAccounts(int id);
    }
}
