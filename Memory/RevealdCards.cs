using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class RevealdCards
    {
        public Card?[] revealdCards;

        public RevealdCards()
        {
            revealdCards = new Card[2];
        }

        public void AddRevealCard(Card? card)
        {
            if (revealdCards[0] == null)
            {
                revealdCards[0] = card;
            }
            else
            {
                revealdCards[1] = card;
            }
        }

        public void ClearRevealCards()
        {
            revealdCards[0] = null;
            revealdCards[1] = null;
        }


    }
}
