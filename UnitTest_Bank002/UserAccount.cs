using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Bank002
{
    public class UserAccount : IAccount, IDisposable
    {
        public int Id { get; }
        public string Name { get; }
        public int Age { get; }

        public UserAccount(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public void Dispose()
        {
        }

        public List<IAccount> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public IAccount GetAccounts(int id)
        {
            throw new NotImplementedException();
        }
    }
}
