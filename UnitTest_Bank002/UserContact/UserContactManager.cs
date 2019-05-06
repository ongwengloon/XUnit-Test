using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Bank002
{
    public class UserContactManager : IUserContactRepository, IDisposable
    {
        private IUserContactRepository _repository;

        public UserContactManager(IUserContactRepository repository)
        {
            _repository = repository;
        }
        
        public UserContactModel GetContacts(int id)
        {
            return _repository.GetContacts(id);
        }

        public void Dispose()
        {
        }
    }
}
