using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class Board
    {
        private Card?[,]? cards;

        public Card?[,]? Cards { get => cards;}
        public int size;
        public int points;
        public int totalPoints;

        public bool IsCardExist(int posX, int posY, int distanceX)
        {
            return posX - distanceX >= 0 && posX - distanceX < cards.GetLength(0) && posY >= 0 && posY < cards.GetLength(1);
        }

        public Card ReturnCard(int posX, int posY)
        {
            return cards[posX, posY];
        }

        public bool IsCardNull(int posX, int posY)
        {
            return cards[posX, posY] == null;
        }

        public Card? FindFirstCard(int posX, int posY, Direction direction)
        {
            Card? card = null;
            bool isFinded = false;

            switch (direction)
            {
                case Direction.Left:
                    do
                    {
                        if (cards?[posX,posY] != null)
                        {
                            card = cards[posX,posY];
                            isFinded = true;
                        }

                        if(posX == 0 && posY == 0)
                        {
                            posX = size - 1;
                            posY = size - 1;
                        }
                        else if(posX == 0)
                        {
                            posX = size - 1;
                            posY--;
                        }
                        else
                        {
                            posX--;
                        }

                    } while (!isFinded);
                    break;
                case Direction.Right:
                    do
                    {
                        if (cards?[posX, posY] != null)
                        {
                            card = cards[posX, posY];
                            isFinded = true;
                        }

                        if (posX == size - 1 && posY == size - 1)
                        {
                            posX = 0;
                            posY = 0;
                        }
                        else if (posX == size - 1)
                        {
                            posX = 0;
                            posY++;
                        }
                        else
                        {
                            posX++;
                        }

                    } while (!isFinded);
                    break;
                case Direction.Up:
                    do
                    {
                        if (cards?[posX, posY] != null)
                        {
                            card = cards[posX, posY];
                            isFinded = true;
                        }

                        if (posX == 0 && posY == 0)
                        {
                            isFinded = true;
                        }
                        else if (posY == 0)
                        {
                            posX--;
                            posY = size - 1;
                        }
                        else
                        {
                            posY--;
                        }

                    } while (!isFinded);
                    break;
                case Direction.Down:
                    do
                    {
                        if (cards?[posX, posY] != null)
                        {
                            card = cards[posX, posY];
                            isFinded = true;
                        }

                        if (posX == cards.GetLength(0) && posY == cards.GetLength(1))
                        {
                            isFinded = true;
                        }
                        else if (posY == size - 1)
                        {
                            if(posX < size - 1)
                            {
                                posX++;
                            }
                            posY = 0;
                        }
                        else
                        {
                            posY++;
                        }

                    } while (!isFinded);
                    break;
                default:
                    break;
            }

            return card;
        }

        public void RemoveCardFromBoard(Card card, int distanceX)
        {
            cards[card.position.X - distanceX, card.position.Y] = null;
            points++;
        }

        public void Draw(int distanceX)
        {
            cards = new Card[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    cards[i,j] = new Card(distanceX,j);
                }
                distanceX++;
            }

            totalPoints = size * size;
        }
    }
}
