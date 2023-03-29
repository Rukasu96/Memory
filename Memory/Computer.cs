using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class Computer : Player
    {
        private Board boardAI;
        private int distanceX;
        private List<Card> revealedcards;

        public Computer(Board boardAI, int distanceX) : base()
        {
            this.boardAI = boardAI;
            Position.X = 10;
            this.distanceX = distanceX;
            isPlaying = false;

            revealedcards = new List<Card>();
        }

        public override void DoTurn()
        {
            if (!isPlaying)
            {
                return;
            }

            Card? temporaryCard = null;

            Console.SetCursorPosition(Position.X, Position.Y);

            Random rand = new Random();
            int movesCount = DrawMoves(3, 10);

            for (int i = 0; i < 2; i++)
            {
                if (!isPlaying)
                {
                    return;
                }

                Card? revealedCard = null;

                if (revealedcards.Count > 0 && temporaryCard != null)
                {
                    revealedCard = revealedcards.FirstOrDefault(x => 
                    ((x.ReverseModel == temporaryCard.ReverseModel) && (x.position.X != temporaryCard.position.X)) || 
                    ((x.ReverseModel == temporaryCard.ReverseModel) && (x.position.Y != temporaryCard.position.Y)));
                    
                }

                if (revealedCard != null)
                {
                    MoveToCard(revealedCard);
                }
                else
                {

                    for (int j = 0; j < movesCount; j++)
                    {
                        int result = rand.Next(0, 4);

                        switch (result)
                        {
                            case 0:
                                if (boardAI.IsCardExist(Position.X - distanceX, Position.Y - 1))
                                {
                                    Move(Direction.Up, boardAI, distanceX);
                                }
                                break;
                            case 1:
                                if (boardAI.IsCardExist(Position.X - distanceX, Position.Y + 1))
                                {
                                    Move(Direction.Down, boardAI, distanceX);
                                }
                                break;
                            case 2:
                                if (boardAI.IsCardExist(Position.X - distanceX - 1, Position.Y))
                                {
                                    Move(Direction.Left, boardAI, distanceX);
                                }
                                break;
                            case 3:
                                if (boardAI.IsCardExist(Position.X - distanceX + 1, Position.Y))
                                {
                                    Move(Direction.Right, boardAI, distanceX);
                                }
                                break;
                            default:
                                break;
                        }

                    }
                }

                CardManager.Instance.RevealCard(boardAI, Position.X, Position.Y, distanceX);

                temporaryCard = boardAI.Cards[Position.X - distanceX, Position.Y];

                if(revealedcards.FirstOrDefault(x => x == temporaryCard) == null)
                {
                    if (TryToAddReveleadCard())
                    {
                        revealedcards.Add(temporaryCard);
                    }
                }

                if (revealedcards.Contains(null))
                {
                    revealedcards.Remove(revealedCard);
                }

                Thread.Sleep(200);
            }
            
        }

        private int DrawMoves(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max);
        }

        private bool TryToAddReveleadCard()
        {
            Random rand = new Random();
            int randNumb = rand.Next(0, 5);

            if(randNumb >= 0) 
            {
                return true;
            }

            return false;
        }

        private void MoveToCard(Card? temporaryCard)
        {
            Random rand = new Random();
            bool IsOnCardPosition = false;

            while (!IsOnCardPosition)
            {
                int randNumb = rand.Next(0, 2);

                switch (randNumb)
                {
                    case 0:
                        if (temporaryCard.position.X > Position.X)
                        {
                            Move(Direction.Right, boardAI, distanceX);
                        }
                        else if (temporaryCard.position.X < Position.X)
                        {
                            Move(Direction.Left, boardAI, distanceX);
                        }
                        break;
                    case 1:
                        if (temporaryCard.position.Y > Position.Y)
                        {
                            Move(Direction.Down, boardAI, distanceX);
                        }
                        else if (temporaryCard.position.Y < Position.Y)
                        {
                            Move(Direction.Up, boardAI, distanceX);
                        }
                        break;
                    default:
                        break;
                }

                if(Position.X == temporaryCard.position.X && Position.Y == temporaryCard.position.Y)
                {
                    IsOnCardPosition = true;
                }
                
            }
           
        }
    }
}
