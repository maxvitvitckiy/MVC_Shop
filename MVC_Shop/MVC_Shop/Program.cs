using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Admin adm = new Admin("admin_001", "password_admin_001", "name_admim_001");
            if (adm.CheckLogin("admin_001", "password_admin_001")) Console.WriteLine("Yes");
            else Console.WriteLine("No");
            Console.ReadLine();
        }
    }
}
