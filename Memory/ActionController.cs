using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class ActionController
    {
        public ActionController(Player player,int distanceX, Board board, Keyboard Keyboard)
        {
            Keyboard.OnUp += CreateMove(player, distanceX, board, Direction.Up, () => player.Position.X, () => player.Position.Y - 1);
            Keyboard.OnDown += CreateMove(player, distanceX, board, Direction.Down, () => player.Position.X, () => player.Position.Y + 1);
            Keyboard.OnLeft += CreateMove(player, distanceX, board, Direction.Left, () => player.Position.X - 1, () => player.Position.Y);
            Keyboard.OnRight += CreateMove(player, distanceX, board, Direction.Right, () => player.Position.X + 1, () => player.Position.Y);

            Keyboard.OnEnter += () => CardManager.Instance.RevealCard(board, player.Position.X, player.Position.Y, distanceX);

        }

        private Action CreateMove(Player player,int distanceX, Board board, Direction direction, Func<int> positionX, Func<int> positionY)
        {
            return () =>
            {
                if (board.IsCardExist(positionX(), positionY(), distanceX))
                {
                    player.Move(direction, board, distanceX);
                }
            };
        }

        

    }
}
