using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Shop
{
    class Controller
    {
        static public bool CheckItem(Person p, Item it)
        {
            if (p is Guest && it.Count <= 5) return false;
            else return true;
        }
        static public bool LoginCheck(Person p, string login, string password)
        {
            if (p is Guest) return false;
            if (p.Login == login && p.Password == password) return true;
            return false;
        }
        static public bool CheckLogin(Person p, string login, string password)
        {
            if (login == p.Login && password == p.Password)
                return true;
            return false;
        }
    }
}
