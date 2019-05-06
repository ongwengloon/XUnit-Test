using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Bank002
{
    public interface IUserContactRepository
    {
        UserContactModel GetContacts(int userAccountId);
    }
}
