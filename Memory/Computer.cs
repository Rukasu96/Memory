using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class Computer : Player
    {
        private Board boardAI;

        public Computer(Board boardAI) : base()
        {
            this.boardAI = boardAI;
            Position.X = 10;
        }

        public override void DoTurn()
        {
            Console.SetCursorPosition(10, 0);

            Random rand = new Random();
            int movesCount = DrawMoves(3, 10);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < movesCount; j++)
                {
                    int result = rand.Next(0, 4);

                    switch (result)
                    {
                        case 0:
                            if (boardAI.IsCardExist(Position.X, Position.Y - 1))
                            {
                                Move(Direction.Up);
                            }
                            break;
                        case 1:
                            if (boardAI.IsCardExist(Position.X, Position.Y + 1))
                            {
                                Move(Direction.Down);
                            }
                            break;
                        case 2:
                            if (boardAI.IsCardExist(Position.X - 1, Position.Y))
                            {
                                Move(Direction.Left);
                            }
                            break;
                        case 3:
                            if (boardAI.IsCardExist(Position.X + 1, Position.Y))
                            {
                                Move(Direction.Right);
                            }
                            break;
                        default:
                            break;
                    }

                }

                CardManager.Instance.RevealCard(boardAI, Position.X, Position.Y);
            }
            
        }

        private int DrawMoves(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max);
        }
    }
}
