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
        public override void DoTurn()
        {
            
        }

        public void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.Left:
                    Position.X -= 1;
                    break; 
                case Direction.Right:
                    Position.X += 1;
                    break;
                    case Direction.Up:
                    Position.Y -= 1;
                    break;
                    case Direction.Down:
                    Position.Y += 1;
                    break;
                default:
                    break;
            }

            Console.SetCursorPosition(Position.X, Position.Y);
        }
    }
}
