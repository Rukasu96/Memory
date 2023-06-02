using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class Menu : MenuItem
    {
        private List<MenuItem> menuItems;
        private bool isMainMenu;

        public State _state;

        public Menu(string title, bool isMainMenu) : base(title)
        {
            menuItems = new List<MenuItem>();
            Action = () => Run();
            this.isMainMenu = isMainMenu;
            _state = State.Off;
        }

        public void Add(MenuItem menuItem)
        {
            menuItems.Add(menuItem);
        }

        private void ShowMenu()
        {
            int opt = 1;
            menuItems.ForEach(x => Console.WriteLine($"{opt++}. {x.Title}"));

            if (isMainMenu)
            {
                Console.WriteLine($"{opt}. Wyjście.");
            }
            else
            {
                Console.WriteLine($"{opt}. Cofnij.");
            }
        }

        public void Run()
        {
            int option = -1;
            while (option != menuItems.Count + 1 && _state == State.Off)
            {
                ShowMenu();
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    option = int.Parse(Console.ReadLine());
                    if (option >= 1 && option <= menuItems.Count)
                    {
                        Console.Clear();
                        menuItems[option - 1].Action?.Invoke();
                    }
                    else if (option == menuItems.Count + 1 && isMainMenu)
                    {
                        Console.WriteLine("Wyjscie");
                        Environment.Exit(0);
                    }
                    else if (option == menuItems.Count + 1)
                    {
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Niepoprawna wartosc");
                }
            }
        }

        
    }
}
