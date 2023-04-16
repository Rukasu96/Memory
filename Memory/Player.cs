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
        protected ActionController actionController;
        protected Keyboard keyboard;

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
            keyboard = new Keyboard();
            TurnController.Instance.AddPlayers(this);
        }
        public abstract void DoTurn();
        public void Move(Direction dir, Board board, int distanceX)
        {
            switch (dir)
            {
                case Direction.Left:
                    if (board.IsCardExist(Position.X - distanceX - 1, Position.Y))
                    {
                        MakeMoveHorizontal(0, board.size - 1, -1);
                    }
                    break;
                case Direction.Right:
                    if (board.IsCardExist(Position.X - distanceX + 1, Position.Y))
                    {
                        MakeMoveHorizontal(board.size - 1, 0, 1);
                    }
                    break;
                case Direction.Up:
                    if (board.IsCardExist(Position.X - distanceX, Position.Y - 1))
                    {
                        MakeMoveVertical(0, board.size - 1, -1);
                    }
                    break;
                case Direction.Down:
                    if (board.IsCardExist(Position.X - distanceX, Position.Y + 1))
                    {
                        MakeMoveVertical(board.size -1, 0, 1);
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

        private void MakeMoveHorizontal(int RightLeftMaxPosition, int boardSize, int increaseValue)
        {
            if (Position.X == RightLeftMaxPosition && Position.Y != RightLeftMaxPosition)
            {
                Position.X = boardSize;
                Position.Y = Position.Y + increaseValue;
            }
            else
            {
                Position.X = Position.X + increaseValue;
            }
        }

        private void MakeMoveVertical(int UpDownMaxPosition, int boardSize, int increaseValue)
        {
            if (Position.X != UpDownMaxPosition && Position.Y == UpDownMaxPosition)
            {
                Position.X = Position.X + increaseValue;
                Position.Y = boardSize;
            }
            else
            {
                Position.Y = Position.Y + increaseValue;
            }
        }

        private void JumpToCard(int positionX, int positionY, Direction direction,Board board)
        {
            if (board.FindFirstCard(positionX, positionY, direction) == null)
            {
                return;
            }

            Card? card = board.FindFirstCard(positionX, positionY, direction);

            Position.X = card.position.X;
            Position.Y = card.position.Y;

            Console.SetCursorPosition(Position.X, Position.Y);
        }

        

    }
}
