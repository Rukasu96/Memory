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
        private List<Card> revealedCards;
        private List<Card> notRevealedCards;
        private Card? firstTemporaryCard;
        private Card? secondTemporaryCard;

        public Difficulty difficulty; 

        public Computer(Board boardAI, int distanceX) : base()
        {
            this.boardAI = boardAI;
            Position.X = 10;
            this.distanceX = distanceX;
            isPlaying = false;
            actionController = new ActionController(this, distanceX, boardAI, keyboard);
            revealedCards = new List<Card>();
            difficulty = Difficulty.Medium;
            AddCardsToList();
        }

        public override void DoTurn()
        {
            if (!isPlaying)
            {
                return;
            }

            RemoveRevealedCardFromList(firstTemporaryCard, secondTemporaryCard);

            firstTemporaryCard = null;

            for (int i = 0; i < 2; i++)
            {
                if (!isPlaying)
                {
                    return;
                }

                Console.SetCursorPosition(Position.X, Position.Y);

                Card? cardToReveal = null;

                if(revealedCards.Count >= 2 && firstTemporaryCard == null)
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
                else if (revealedCards.Count > 0 && firstTemporaryCard != null)
                {
                    cardToReveal = FindTheSameCard(firstTemporaryCard);
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
                                keyboard.ButtonPressed(ConsoleKey.UpArrow);
                                break;
                            case 1:
                                keyboard.ButtonPressed(ConsoleKey.DownArrow);
                                break;
                            case 2:
                                keyboard.ButtonPressed(ConsoleKey.LeftArrow);
                                break;
                            case 3:
                                keyboard.ButtonPressed(ConsoleKey.RightArrow);
                                break;
                            default:
                                break;
                        }

                        Thread.Sleep(200);
                    }

                    ComputerRevealCard(cardToReveal);

                }

            }
            
        }

        private bool TryToAddReveleadCard()
        {
            Random rand = new Random();
            int randNumb = rand.Next(0, 5);

            if(randNumb <= (int) difficulty) 
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
                            keyboard.ButtonPressed(ConsoleKey.RightArrow);
                        }
                        else if (cardToReveal.position.X < Position.X)
                        {
                            keyboard.ButtonPressed(ConsoleKey.LeftArrow);
                        }
                        break;
                    case 1:
                        if (cardToReveal.position.Y > Position.Y)
                        {
                            keyboard.ButtonPressed(ConsoleKey.DownArrow);
                        }
                        else if (cardToReveal.position.Y < Position.Y)
                        {
                            keyboard.ButtonPressed(ConsoleKey.UpArrow);
                        }
                        break;
                    default:
                        break;
                }

                if(Position.X == cardToReveal.position.X && Position.Y == cardToReveal.position.Y)
                {
                    IsOnCardPosition = true;
                }
                Thread.Sleep(200);

            }

            ComputerRevealCard(cardToReveal);
        }

        private void ComputerRevealCard(Card? cardToReveal)
        {
            firstTemporaryCard = boardAI.Cards[Position.X - distanceX, Position.Y];

            if (cardToReveal != null)
            {
                firstTemporaryCard = cardToReveal;
            }

            if (revealedCards.FirstOrDefault(x => x == firstTemporaryCard) == null)
            {
                if (TryToAddReveleadCard())
                {
                    revealedCards.Add(firstTemporaryCard);
                }
            }

            CardManager.Instance.RevealCard(boardAI, Position.X, Position.Y, distanceX);

            if(firstTemporaryCard != null)
            {
                secondTemporaryCard = cardToReveal;
            }

            /*if(secondTemporaryCard != null)
            {
                RemoveRevealedCardFromList(firstTemporaryCard, secondTemporaryCard);
            }*/

            Thread.Sleep(200);
        }
        
        private void RevealTwoTheSameCards(Card firstCard, Card secondCard)
        {
            MoveToCard(firstCard);
            MoveToCard(secondCard);
        }

        private void RemoveRevealedCardFromList(Card firstCardToRemove, Card secondCardToRemove)
        {
            if(firstCardToRemove != null && firstCardToRemove.state is Hided)
            {
                return;
            }

            revealedCards.Remove(firstCardToRemove);
            revealedCards.Remove(secondCardToRemove);
            
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
