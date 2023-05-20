using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class ChooseOpponentMenuItem : MenuItem
    {
        private GameManager gameManager;

        public ChooseOpponentMenuItem(GameManager gameManager) : base("Przeciwnik")
        {
            this.gameManager = gameManager;
            Action = ChooseOpponent;
        }

        private void ChooseOpponent()
        {
            int index = 1;
            
            bool isOk;

            Console.WriteLine("1. 2 Graczy");
            Console.WriteLine("2. Komputer");

            do
            {
                isOk = false;
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    if (result == 1)
                    {
                        gameManager.IsPlayer = true;
                        isOk = true;
                    }else if(result == 2)
                    {
                        gameManager.IsPlayer = false;
                        isOk = true;
                    }
                }
                else
                {
                    Console.WriteLine("Wybierz 1 lub 2");
                }
            } while (!isOk);

            Console.Clear();
        }
    }
}
