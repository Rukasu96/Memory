using Memory;
using System.Security.Cryptography;
using static Memory.Player;

Board board = new Board();
Board boardAI = new Board();
Menu menu = new Menu("Menu Główne");
menu.Add(new StartGameMenuItem(board, boardAI));
menu.Run();

board.Draw(0);
boardAI.Draw(10);

Human human = new Human();
Keyboard keyboard = new Keyboard();
ActionController actionController = new ActionController(human, board, keyboard);

CardManager.Instance.SetRandomModel();

while (true)
{
    Console.SetCursorPosition(human.Position.X, human.Position.Y);

    var input = Console.ReadKey().Key;

    keyboard.ButtonPressed(input);

}



