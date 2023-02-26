using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class StartGameMenuItem : MenuItem
    {
        private Board board;
        private Board boardAi;

        public StartGameMenuItem(Board board, Board boardAi) : base("Start")
        {
            this.board = board;
            this.boardAi = boardAi;
            Action = ChooseSize;
        }

        private void ChooseSize()
        {
            int size01 = 4;
            int size02 = 6;
            int size03 = 8;
            bool isOk;

            Console.WriteLine($"1. Rozmiar {size01}x{size01}");
            Console.WriteLine($"2. Rozmiar {size02}x{size02}");
            Console.WriteLine($"3. Rozmiar {size03}x{size03}");

            do
            {
                isOk = false;

                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    switch (result)
                    {
                        case 1:
                            board.size = size01;
                            boardAi.size = size01;
                            break;
                        case 2:
                            board.size = size02;
                            boardAi.size = size02;
                            break;
                        case 3:
                            board.size = size03;
                            boardAi.size = size03;
                            break;
                        default:
                            Console.WriteLine("Wybierz 1, 2 lub 3");
                            break;
                    }
                    isOk = true;
                }
                else
                {
                    Console.WriteLine("Wybierz 1, 2 lub 3");
                }
            } while (!isOk);

            Console.Clear();
        }
    }
}
