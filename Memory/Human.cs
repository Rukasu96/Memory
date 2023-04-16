using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Memory.Player;

namespace Memory
{
    internal class Human : Player
    {

        public Human(Board board) : base()
        {
            isPlaying = true;
            actionController = new ActionController(this, 0, board, keyboard);
        }

        public override void DoTurn()
        {
            if (!isPlaying)
            {
                return;
            }

            Console.SetCursorPosition(Position.X, Position.Y);

            var input = Console.ReadKey().Key;

            keyboard.ButtonPressed(input);
        }
       
    }
}
