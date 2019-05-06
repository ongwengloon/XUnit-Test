using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Bank002
{
    public class UserContactModel
    {
        public int UserAccountId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public UserContactModel()
        {
        }

        public UserContactModel(int userAccId, string phone, string email)
        {
            UserAccountId = userAccId;
            Phone = phone;
            Email = email;
        }
    }
}
