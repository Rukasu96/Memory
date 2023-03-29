using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class ReverseModelRandomizer : IRandomizer
    {
        private char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public void SetReverseModel(List<Card> cards)
        {
            for(int i = 0; i < cards.Count; i += 2) 
            {
                cards[i].ReverseModel = alpha[i / 2];
                cards[i+1].ReverseModel = alpha[i / 2];
            }

            Random rand = new Random();
            for(int i = 0; i < 1000; i++)
            {
                int index1 = rand.Next(cards.Count);
                int index2 = rand.Next(cards.Count);
                char model1 = cards[index1].ReverseModel;
                char model2 = cards[index2].ReverseModel;
                cards[index1].ReverseModel = model2;
                cards[index2].ReverseModel = model1;
            }

            CardManager.Instance.ClearList();

        }
    }
}
