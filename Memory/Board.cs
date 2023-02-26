using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class Board
    {
        public Card[,] Cards { get => cards; }
        public int size;

        private Card[,] cards;

        public bool IsCardExist(int posX, int posY)
        {
            return posX >= 0 && posX < cards.GetLength(0) && posY >= 0 && posY < cards.GetLength(1);
        }

        public void RemoveCardFromBoard(Card card)
        {
            cards[card.position.X, card.position.Y] = null;
        }

        public void Draw(int distanceX)
        {
            cards = new Card[distanceX + size, size];

            for (int i = distanceX; i < distanceX + size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    cards[i,j] = new Card(i,j);
                }
            }
        }
    }
}
