using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class ActionController
    {
        public ActionController(Human human, Board board, Keyboard Keyboard)
        {
            Keyboard.OnUp += () =>
            {
                if (board.IsCardExist(human.Position.X, human.Position.Y - 1))
                {
                    human.Move(Direction.Up);
                }
            };

            Keyboard.OnDown += () =>
            {
                if (board.IsCardExist(human.Position.X, human.Position.Y + 1))
                {
                    human.Move(Direction.Down);
                }
            };

            Keyboard.OnLeft += () =>
            {
                if (board.IsCardExist(human.Position.X - 1, human.Position.Y))
                {
                    human.Move(Direction.Left);
                }
            };

            Keyboard.OnRight += () =>
            {
                if (board.IsCardExist(human.Position.X + 1, human.Position.Y))
                {
                    human.Move(Direction.Right);
                }
            };

            Keyboard.OnEnter += () => CardManager.Instance.RevealCard(board, human.Position.X, human.Position.Y);
        }

    }
}
