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
        private Keyboard keyboard;
        private ActionController actionController;

        public Human(Board board) : base()
        {
            keyboard = new Keyboard();
            actionController = new ActionController(this, board, keyboard);
            isPlaying = true;
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
