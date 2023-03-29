using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class CardManager
    {
        private RevealdCards revealdCards;
        private IRandomizer modelRandomizer;
        private List<Card> cards;

        private static CardManager? instance = null;
        public static CardManager Instance
        {
            get { 
                if(instance == null)
                {
                    instance = new CardManager(new ReverseModelRandomizer());
                }
                return instance;
            }
        }

        private CardManager(IRandomizer modelRandomizer)
        {
            revealdCards = new RevealdCards();
            this.modelRandomizer = modelRandomizer;
            cards = new List<Card>();
        }
        
        public void RevealCard(Board board, int posX, int posY, int distanceX)
        {
            if(board.Cards[posX - distanceX, posY] == null)
            {
                return;
            }
            else if (board.Cards[posX - distanceX, posY].state is Revealed)
            {
                return;
            }
            Card card = board.Cards[posX - distanceX, posY];
            card.TurnCard();

            revealdCards.AddRevealCard(card);

            if (revealdCards.revealdCards[1] != null)
            {
                CheckCards(revealdCards.revealdCards[0], revealdCards.revealdCards[1], board, distanceX);
            }
        }

        
        private void CheckCards(Card card, Card card2, Board board, int distanceX)
        {
            if (card.ReverseModel == card2.ReverseModel)
            {
                Thread.Sleep(500);
                revealdCards.ClearRevealCards();
                card.RemoveCard();
                card2.RemoveCard();
                board.RemoveCardFromBoard(card, distanceX);
                board.RemoveCardFromBoard(card2, distanceX);
            }
            else
            {
                Thread.Sleep(1000);
                card.TurnCard();
                card2.TurnCard();
                revealdCards.ClearRevealCards();
            }

            TurnController.Instance.ChangePlayer();
        }

        public void AddCardToList(Card card)
        {
            cards.Add(card);
        }
        public void ClearList()
        {
            cards.Clear();
        }

        public void SetRandomModel()
        {
            modelRandomizer.SetReverseModel(cards);
        }

        
    }
}
