using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal abstract class Player
    {

        public int Points { get; set; }
        public Coordinate Position { get; set; }
        public Direction Direction { get; set; }

        public Player()
        {
            Position = new Coordinate();
            Direction = new Direction();
            Position.X = 0;
            Position.Y = 0;
        }
        public abstract void DoTurn();
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
            Thread.Sleep(500);
        }

    }
}
