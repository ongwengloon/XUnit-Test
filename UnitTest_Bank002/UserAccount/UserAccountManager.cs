using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Bank002
{
    public class UserAccountManager : IUserAccountRepository, IDisposable
    {
        private IUserAccountRepository _repository;
        private IUserContactRepository _contactRepository;

        public UserAccountManager(IUserAccountRepository repository, IUserContactRepository contactRepository)
        {
            _repository = repository;
            _contactRepository = contactRepository;
        }

        public void Dispose()
        {
        }

        public List<UserAccountModel> GetAccounts()
        {
            return _repository.GetAccounts();
        }

        public UserAccountModel GetAccounts(int id)
        {
            var user = GetAccounts().FirstOrDefault(x => x.Id == id);

            if(user != null)
                user.Contact = _contactRepository.GetContacts(id);

            return user;
        }
    }
}
