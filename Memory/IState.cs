﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal interface IState
    {
        public void TurnCard(Card card);
    }
}
