using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
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
        private List<Card> revealedCards;
        private List<Card> notRevealedCards;
        private Card? temporaryCard;

        public Computer(Board boardAI, int distanceX) : base()
        {
            this.boardAI = boardAI;
            Position.X = 10;
            this.distanceX = distanceX;
            isPlaying = false;

            revealedCards = new List<Card>();
            AddCardsToList();
        }

        public override void DoTurn()
        {
            if (!isPlaying)
            {
                return;
            }

            temporaryCard = null;

            Console.SetCursorPosition(Position.X, Position.Y);

            for (int i = 0; i < 2; i++)
            {
                if (!isPlaying)
                {
                    return;
                }

                Card? cardToReveal = null;

                if(revealedCards.Count >= 2 && temporaryCard == null)
                {
                    bool HasTwoSameCard = false;

                    for (int z = 0; z < revealedCards.Count - 1; z++)
                    {
                        Card firstCardInMemory = revealedCards[z];

                        var secondCardInMemory = FindTheSameCard(firstCardInMemory);

                        if (secondCardInMemory != null)
                        {
                            RevealTwoTheSameCards(firstCardInMemory, secondCardInMemory);
                            HasTwoSameCard = true;
                            break;
                        }

                    }

                    if(HasTwoSameCard)
                    {
                        break;
                    }

                }
                else if (revealedCards.Count > 0 && temporaryCard != null)
                {
                    cardToReveal = FindTheSameCard(temporaryCard);
                }else if(notRevealedCards.Count > 0)
                {
                    cardToReveal = DrawNotRevealedCard();
                }

                if (cardToReveal != null)
                {
                    MoveToCard(cardToReveal);
                }
                else
                {
                    int movesCount = RandomNumber.GenerateNumber(3, 10);

                    for (int j = 0; j < movesCount; j++)
                    {
                        int result = RandomNumber.GenerateNumber(0, 4);

                        switch (result)
                        {
                            case 0:
                                Move(Direction.Up, boardAI, distanceX);
                                break;
                            case 1:
                                Move(Direction.Down, boardAI, distanceX);
                                break;
                            case 2:
                                Move(Direction.Left, boardAI, distanceX);
                                break;
                            case 3:
                                Move(Direction.Right, boardAI, distanceX);
                                break;
                            default:
                                break;
                        }

                    }

                    ComputerRevealCard(cardToReveal);

                }

            }
            
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

        private void MoveToCard(Card? cardToReveal)
        {
            Random rand = new Random();
            bool IsOnCardPosition = false;

            while (!IsOnCardPosition)
            {
                int randNumb = rand.Next(0, 2);

                switch (randNumb)
                {
                    case 0:
                        if (cardToReveal.position.X > Position.X)
                        {
                            Move(Direction.Right, boardAI, distanceX);
                        }
                        else if (cardToReveal.position.X < Position.X)
                        {
                            Move(Direction.Left, boardAI, distanceX);
                        }
                        break;
                    case 1:
                        if (cardToReveal.position.Y > Position.Y)
                        {
                            Move(Direction.Down, boardAI, distanceX);
                        }
                        else if (cardToReveal.position.Y < Position.Y)
                        {
                            Move(Direction.Up, boardAI, distanceX);
                        }
                        break;
                    default:
                        break;
                }

                if(Position.X == cardToReveal.position.X && Position.Y == cardToReveal.position.Y)
                {
                    IsOnCardPosition = true;
                }

            }

            ComputerRevealCard(cardToReveal);
        }

        private void ComputerRevealCard(Card? cardToReveal)
        {
            temporaryCard = boardAI.Cards[Position.X - distanceX, Position.Y];

            if (revealedCards.FirstOrDefault(x => x == temporaryCard) == null)
            {
                if (TryToAddReveleadCard())
                {
                    revealedCards.Add(temporaryCard);
                }
            }

            CardManager.Instance.RevealCard(boardAI, Position.X, Position.Y, distanceX);

            if(revealedCards.Count > 0)
            {
                RemoveRevealedCardFromList(temporaryCard);
            }

            Thread.Sleep(200);
        }
        
        private void RevealTwoTheSameCards(Card firstCard, Card secondCard)
        {
            MoveToCard(firstCard);
            MoveToCard(secondCard);
            revealedCards.Remove(firstCard);
            revealedCards.Remove(secondCard);
        }

        private void RemoveRevealedCardFromList(Card cardToRemove)
        {
            var cardsToRemove = revealedCards.Where(x => x == null || x.state is Revealed ).ToList();

            foreach(Card card in cardsToRemove)
            {
                revealedCards.Remove(card);
            }

            cardsToRemove.Clear();
        }

        private Card? FindTheSameCard(Card card)
        {
            return revealedCards.FirstOrDefault(x =>
            ((x.ReverseModel == card.ReverseModel) && (x.position.X != card.position.X)) ||
            ((x.ReverseModel == card.ReverseModel) && (x.position.Y != card.position.Y)));
        }

        private Card? DrawNotRevealedCard()
        {
            Card card;
            int posX;
            int posY;

            do
            {
                posX = RandomNumber.GenerateNumber(0, boardAI.size);
                posY = RandomNumber.GenerateNumber(0, boardAI.size);

                card = boardAI.ReturnCard(posX, posY);

            } while (card == null);

            notRevealedCards.Remove(card);
            return card;
        }

        private void AddCardsToList()
        {
            notRevealedCards = new List<Card>();
            for (int i = 0; i < boardAI.size; i++)
            {
                for (int j = 0; j < boardAI.size; j++)
                {
                    notRevealedCards.Add(boardAI.ReturnCard(i, j));
                }
            }
        }
    }
}
