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

    }
}
