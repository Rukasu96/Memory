using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class StartGameMenuItem : MenuItem
    {
        private Board[] boards;
        private Menu mainMenu;
        private GameManager gameManager;

        public StartGameMenuItem(GameManager gameManager, Menu MainMenu) : base("Start")
        {
            this.gameManager = gameManager;
            Action = ChooseSize;
            this.mainMenu = MainMenu;
        }
        
        private void ChooseSize()
        {
            int[] sizes = Enum.GetValues(typeof(Size)).Cast<int>().ToArray();
            int index = 1;
            int size = 0;
            bool isOk;

            foreach (int value in sizes)
            {
                Console.WriteLine($"{index}. Rozmiar {value}x{value}");
                index++;
            }
            
            do
            {
                isOk = false;
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    if(result > 0 && result <= sizes.Length)
                    {
                        size = sizes[result - 1];
                        isOk = true;
                    }

                    mainMenu.state = State.On;
                }
                else
                {
                    Console.WriteLine("Wybierz 1, 2 lub 3");
                }
            } while (!isOk);

            gameManager.Size = size;
            /*foreach(Board board in boards)
            {
                board.size = size;
            }*/

            Console.Clear();
        }
    }
}
