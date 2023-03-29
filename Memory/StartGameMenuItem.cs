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
        public StartGameMenuItem(Board[] boards) : base("Start")
        {
            this.boards = boards;
            Action = ChooseSize;
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
                    
                }
                else
                {
                    Console.WriteLine("Wybierz 1, 2 lub 3");
                }
            } while (!isOk);

            foreach(Board board in boards)
            {
                board.size = size;
            }

            Console.Clear();
        }
    }
}
