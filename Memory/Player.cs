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

        public bool isPlaying;
        public Player()
        {
            Position = new Coordinate();
            Direction = new Direction();
            Position.X = 0;
            Position.Y = 0;
            TurnController.Instance.AddPlayers(this);
        }
        public abstract void DoTurn();
        public void Move(Direction dir, Board board, int distanceX)
        {
            switch (dir)
            {
                case Direction.Left:
                    if (Position.X == 0 && Position.Y != 0)
                    {
                        Position.X = board.size - 1;
                        Position.Y--;
                    }
                    else
                    {
                        Position.X--;
                    }
                    break;
                case Direction.Right:
                    if (Position.X == board.size - 1 && Position.Y != board.size - 1)
                    {
                        Position.X = 0;
                        Position.Y++;
                    }
                    else
                    {
                        Position.X++;
                    }
                    break;
                case Direction.Up:
                    if (Position.X != 0 && Position.Y == 0)
                    {
                        Position.X--;
                        Position.Y = board.size - 1;
                    }
                    else
                    {
                        Position.Y--;
                    }
                    break;
                case Direction.Down:
                    if (Position.X != board.size - 1 && Position.Y == board.size - 1)
                    {
                        Position.X++;
                        Position.Y = 0;
                    }
                    else
                    {
                        Position.Y++;
                    }
                    break;
                default:
                    break;
            }

            if (board.IsCardNull(Position.X - distanceX, Position.Y))
            {
                JumpToCard(Position.X - distanceX, Position.Y, dir, board);
            }
            else 
            {
            Console.SetCursorPosition(Position.X, Position.Y);
            }


        }

        private void JumpToCard(int positionX, int positionY, Direction direction,Board board)
        {
            if (board.FindFirstCard(positionX, positionY, direction) == null)
            {
                return;
            }

            Card card = board.FindFirstCard(positionX, positionY, direction);

            Position.X = card.position.X;
            Position.Y = card.position.Y;

            Console.SetCursorPosition(Position.X, Position.Y);
        }

    }
}
