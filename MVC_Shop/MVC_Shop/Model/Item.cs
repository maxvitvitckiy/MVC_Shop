using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Shop
{
    class Item
    {
        readonly string item_name;
        int count;
        public Item()
        {
            item_name = "item_name";
            count = 0;
        }
        public Item(string item_name)
        {
            this.item_name = item_name;
            count = 0;
        }
        public Item(string item_name, int count)
        {
            this.item_name = item_name;
            if (count >= 0)
                this.count = count;
        }
        public bool AddItemCount(Person p)
        {
            if (p is Admin)
            {
                count++;
                return true;
            }
            else return false;
        }
        public string Item_name
        {
            get { return item_name; }
        }
        public int Count
        {
            get { return count; }
        }
    }
}
