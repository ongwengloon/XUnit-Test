using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Bank002
{
    public class UserContactRepository : IUserContactRepository, IDisposable
    {
        public void Dispose()
        {
        }


        public UserContactModel GetContacts(int userAccountId)
        {
            throw new NotImplementedException();
        }
    }
}
