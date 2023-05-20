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

        public Human(Board board, int distanceX, int positionX, bool isPlaying) : base()
        {
            this.distanceX = distanceX;
            this.isPlaying = isPlaying;
            this.Position.X = positionX;
            actionController = new ActionController(this, distanceX, board, keyboard);
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
