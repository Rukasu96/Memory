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
            //int half = cards.Count/2;
            //char[] usedLetters = new char[half];

            ////Losowanie kart
            //int[] usedIndex = new int[cards.Count];
            //int rand;
            //bool isRepeated = true;

            //for (int i = 0; i < cards.Count - 1; i++)
            //{
            //    rand = new Random().Next(0, cards.Count);
            //    usedIndex[i] = rand;
            //    do
            //    {
            //        rand = new Random().Next(0, cards.Count);
            //        int index = usedIndex.FirstOrDefault(x => x == rand);

            //        if ( index == null)
            //        {
            //            usedIndex[i] = rand;
            //            isRepeated = false;
            //        }

            //    } while (isRepeated);
            //}

            ////Przypisywanie chara do pierwszej połowy kart
            //for (int i = 0; i < half - 1; i++)
            //{
            //    cards[usedIndex[i]].ReverseModel = alpha[i];
            //    usedLetters[i] = alpha[i];
            //}

            ////Przypisywanie chara do drugiej połowy kart
            //int next = 0;
            //for (int i = half; i < cards.Count - 1; i++)
            //{
            //    cards[usedIndex[i]].ReverseModel = usedLetters[next];
            //    next++;
            //}

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
