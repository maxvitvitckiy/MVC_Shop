using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Shop
{
    class View
    {
        void ShowItems(Person p, List<Item> items)
        {
           foreach(Item it in items)
            {
                if (Controller.CheckItem(p, it)) ShowOneItem(it);
                else continue;
            } 
        }
        
        void ShowOneItem(Item it)
        {
            Console.WriteLine("Item name: {0}\nItem count: {1}\n", it.Item_name, it.Count);
        }

        void ShowItemsName(Person p, List<Item> items)
        {
            Console.Write("Item name you are looking for: ");
            string it_name = Console.ReadLine();
            bool item_found = false;

            foreach(Item it in items)
            {
               
                if (it.Item_name == it_name)
                {
                    if (Controller.CheckItem(p, it)) ShowOneItem(it);
                    item_found = true;
                }
                else continue;
            }
            if (!item_found) Console.WriteLine("Item has not been found.");
        }

        bool Login(Person p)
        {
            
            Console.Write("Login: ");
            string login = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            return Controller.LoginCheck(p, login, password);
        }
        public void Start()
        {
            Person p;
            Console.WriteLine("Login(1) or continue as a guest?(2)");
            int flag;
            int.TryParse(Console.ReadLine(), out flag);
            if (flag == 1)
            {
                do
                {
                    Console.WriteLine("Login as an admin(1) or as an client(2)?");
                    int flagLogin;
                    int.TryParse(Console.ReadLine(), out flagLogin);
                    if (flagLogin == 1)
                    {
                        p = new Admin("admin", "admin_password", "admin_name");
                        break;
                    }

                    else if (flagLogin == 2)
                    {
                        p = new Client("client", "client_password", "client_email", "client_name");
                        break;
                    }
                    else Console.WriteLine("Wrong value.");
                }while(true);
                do
                {
                    if (Login(p))
                    {
                        Console.WriteLine("You have successfully logged in.");
                        break;
                    }
                    else Console.WriteLine("Wrong login or password. Try again.");
                } while (true) ;
            }
            else p = new Guest();

        }
        void Menu(Person p, List<Item> items)
        {
            int ch;
            do
            {
                Console.WriteLine("1 - Show all items");
                Console.WriteLine("2 - Find items by name");
                Console.WriteLine("0 - exit");
            } while (true);
        }

        void MenuAdmin(Admin p, List<Item> items)
        {
            int ch;
            do
            {

                Console.WriteLine("1 - Show all items");
                Console.WriteLine("2 - Find items by name");
                Console.WriteLine("3 - Delete item");
                Console.WriteLine("4 - Add item");
                Console.WriteLine("5 - Add item count");
                Console.WriteLine("0 - exit");
                int.TryParse(Console.ReadLine(), out ch);
                
                if(ch == 1)
                    ShowItems(p, items);
                if (ch == 2)
                    ShowItemsName(p, items);
                if(ch == 3)
                {
                    Console.WriteLine("Item index you want to delete: ");
                    int index;
                    int.TryParse(Console.ReadLine(), out index);
                    p.DeleteItem(index, items);
                }
                if(ch == 4)
                {
                    int item_count;
                    string item_name;
                    Console.WriteLine("Item name: ");
                    Console.WriteLine("Item count: ");
                }
            } while (true);

        }
    }
}
