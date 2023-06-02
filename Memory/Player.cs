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
        protected int distanceX;

        public int Points;
        public Coordinate Position;
        public Direction Direction;

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
                        MakeMoveHorizontal(0, board, board.size - 1, -1, Position.X - 1, distanceX);
                    break;
                case Direction.Right:
                        MakeMoveHorizontal(board.size, board, board.size - 1, 1, Position.X + 1, distanceX);
                    break;
                case Direction.Up:
                        MakeMoveVertical(0, board, board.size - 1, -1, Position.Y - 1, distanceX);
                    break;
                case Direction.Down:
                        MakeMoveVertical(board.size, board, board.size - 1, 1, Position.Y + 1, distanceX);
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

        private void MakeMoveHorizontal(int RightLeftMaxPosition, Board board, int boardSize, int increaseValue, int checkingCardPosX, int distanceX)
        {
            if (board.IsCardExist(checkingCardPosX, Position.Y, distanceX))
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
        }

        private void MakeMoveVertical(int UpDownMaxPosition, Board board ,int boardSize, int increaseValue, int checkingCardPosY, int distanceX)
        {
            if (board.IsCardExist(Position.X, checkingCardPosY, distanceX))
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
