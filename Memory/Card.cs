using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class Card
    {
        private char model;
        public IState state;
        public Coordinate position;
        public char Model { get => model;}
        public char ReverseModel;

        public Card(int posX, int posY)
        {
            state = new Hided();
            model = 'X';
            SetPosition(posX, posY);
            Draw(model);
            CardManager.Instance.AddCardToList(this);
        }

        public void SetState(IState state)
        {
            this.state = state;
        }

        public void TurnCard()
        {
            state.TurnCard(this);
        }

        private void SetPosition(int posX, int posY)
        {
            position = new Coordinate
            {
                X = posX,
                Y = posY
            };
        }

        public void Draw(char model)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(model);
        }

        public void RemoveCard()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(" ");
        }
    }
}
