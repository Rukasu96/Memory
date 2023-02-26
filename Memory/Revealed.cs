using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class Revealed : IState
    {
        public void TurnCard(Card card)
        {
            card.SetState(new Hided());
            card.Draw(card.Model);
        }
    }
}
