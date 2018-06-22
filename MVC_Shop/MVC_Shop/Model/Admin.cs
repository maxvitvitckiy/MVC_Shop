using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Shop
{
    class Admin : Person
    {

        public Admin() : base()
        {
        }

        public Admin(string login, string password, string name) : base(login, password, name)
        {
        }

        
        public void AddItem(string item_name, int item_count, List<Item> items)
        {
            items.Add(new MVC_Shop.Item(item_name, item_count));
        }

        public void DeleteItem(int index, List<Item> items)
        {
            items.Remove(items[index]);
        }
    }
}
