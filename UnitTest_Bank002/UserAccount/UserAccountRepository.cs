using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Bank002
{
    public class UserAccountRepository : IUserAccountRepository, IDisposable
    {
        public void Dispose()
        {
        }

        public List<UserAccountModel> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public UserAccountModel GetAccounts(int id)
        {
            throw new NotImplementedException();
        }
    }
}
