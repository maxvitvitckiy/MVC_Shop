using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Shop
{
    class View
    {
        void StartItems(List<Item> items)
        {
            items.Add(new Item("Car", 10));
            items.Add(new Item("PC", 3));
            items.Add(new Item("Phone", 0));
        }

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
            List<Item> items = new List<Item>();
            StartItems(items);
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
                        MenuAdmin(items);
                    }

                    else if (flagLogin == 2)
                    {
                        MenuClient(items);
                    }
                    else Console.WriteLine("Wrong value.");
                } while (true);
            }
            else
                MenuGuest(items);
            

        }

        void MenuGuest(List<Item> items)
        {
            Guest g = new Guest();
            int ch;
            do
            {
                Console.WriteLine("1 - Show all items");
                Console.WriteLine("2 - Find items by name");
                Console.WriteLine("0 - exit");
                int.TryParse(Console.ReadLine(), out ch);

                switch (ch)
                {
                    case 1:
                        ShowItems(g, items);
                        break;
                    case 2:
                        ShowItemsName(g, items);
                        break;
                }
                if (ch == 0) break;
            } while (true);
        }

        void MenuClient(List<Item> items)
        {
            Client cl = new Client("client", "client_password", "client_email", "client_name");

            do
            {
                if (Login(cl))
                {
                    Console.WriteLine("You have successfully logged in.");
                    break;
                }
                else Console.WriteLine("Wrong login or password. Try again.");
            } while (true);

            int ch;
            do
            {
                Console.WriteLine("1 - Show all items");
                Console.WriteLine("2 - Find items by name");
                Console.WriteLine("0 - exit");
                int.TryParse(Console.ReadLine(), out ch);

                switch (ch)
                {
                    case 1:
                        ShowItems(cl, items);
                        break;
                    case 2:
                        ShowItemsName(cl, items);
                        break;
                }
                if (ch == 0) break;
            } while (true);
        }

        void MenuAdmin(List<Item> items)
        {
            Admin adm = new Admin("admin", "password_admin", "admin_name");
            do
            {
                if (Login(adm))
                {
                    Console.WriteLine("You have successfully logged in.");
                    break;
                }
                else Console.WriteLine("Wrong login or password. Try again.");
            } while (true);
            int ch;
            do
            {
                
                Console.WriteLine("1 - Show all items");
                Console.WriteLine("2 - Find items by name");
                Console.WriteLine("3 - Delete item");
                Console.WriteLine("4 - Add item");
                Console.WriteLine("0 - exit");
                int.TryParse(Console.ReadLine(), out ch);
                
                if(ch == 1)
                    ShowItems(adm, items);
                if (ch == 2)
                    ShowItemsName(adm, items);
                if(ch == 3)
                {
                    Console.WriteLine("Item index you want to delete: ");
                    int index;
                    int.TryParse(Console.ReadLine(), out index);
                    adm.DeleteItem(index, items);
                }
                if(ch == 4)
                {
                    int item_count;
                    string item_name;
                    Console.WriteLine("Item name: ");
                    item_name = Console.ReadLine();
                    Console.WriteLine("Item count: ");
                    int.TryParse(Console.ReadLine(), out item_count);
                    items.Add(new Item(item_name, item_count));
                }
                if (ch == 0) break;
            } while (true);

        }
    }
}
