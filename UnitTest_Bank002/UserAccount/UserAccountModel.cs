using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Bank002
{
    public class UserAccountModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public UserContactModel Contact { get; set; }

        public UserAccountModel()
        {
        }

        public UserAccountModel(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public UserAccountModel(int id, string name, int age, UserContactModel contact)
            : this(id, name, age)
        {
            Contact = contact;
        }
    }
}
