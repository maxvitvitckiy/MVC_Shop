using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Shop
{
    class Client : Person
    {
        readonly string email;

        public Client() : base ()
        {
            email = "email";
        }
        public Client(string login, string password, string email, string name) : base(login, password, name)
        {
            this.email = email;
        }


    }

}
