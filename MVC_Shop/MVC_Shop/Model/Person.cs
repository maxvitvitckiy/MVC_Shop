using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Shop
{
    class Person
    {
        protected string name;
        protected readonly string login;
        protected readonly string password;
        public Person()
        {
            login = "login";
            password = "password";
            name = "name";
        }
        public Person(string name)
        {
            this.name = name;
        }

        public Person(string login, string password, string name)
        {
            this.name = name;
            this.login = login;
            this.password = password;
        }

        public string Login
        {
            get { return login; }
        }
        public string Password
        {
            get { return password; }
        }
    }
}
