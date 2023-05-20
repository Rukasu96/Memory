using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class DifficultyOptionMenuItem : MenuItem
    {
        //private Computer computer;
        private GameManager gameManager;
        public DifficultyOptionMenuItem(GameManager gameManager) : base("Poziom trudności")
        {
            this.gameManager = gameManager;
            Action = ChooseDifficulty;
        }

        private void ChooseDifficulty()
        {
            string[] difficulty = Enum.GetNames(typeof(Difficulty)).ToArray();
            int index = 1;
            bool isOk;

            foreach (string difficult in difficulty)
            {
                Console.WriteLine($"{index}. {difficult}");
                index++;
            }

            do
            {
                isOk = false;
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    if (result > 0 && result <= difficulty.Length)
                    {
                        gameManager.difficulty = (Difficulty)result + 1;
                        isOk = true;
                    }

                }
                else
                {
                    Console.WriteLine("Wybierz 1, 2 lub 3");
                }
            } while (!isOk);
            

            Console.Clear();
            Console.WriteLine($"Ustawiono na {gameManager.difficulty}");
        }
    }
    
}
