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
            Keyboard.OnUp += CreateMove(human, board, Direction.Up, () => human.Position.X, () => human.Position.Y - 1);
            Keyboard.OnDown += CreateMove(human, board, Direction.Down, () => human.Position.X, () => human.Position.Y + 1);
            Keyboard.OnLeft += CreateMove(human, board, Direction.Left, () => human.Position.X - 1, () => human.Position.Y);
            Keyboard.OnRight += CreateMove(human, board, Direction.Right, () => human.Position.X + 1, () => human.Position.Y);

            Keyboard.OnEnter += () => CardManager.Instance.RevealCard(board, human.Position.X, human.Position.Y, 0);

        }

        private Action CreateMove(Human human, Board board, Direction direction, Func<int> positionX, Func<int> positionY)
        {
            return () =>
            {
                if (board.IsCardExist(positionX(), positionY()))
                {
                    human.Move(direction, board, 0);
                }
            };
        }

        

    }
}
