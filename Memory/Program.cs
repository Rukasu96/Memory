using Memory;
using System.Security.Cryptography;
using static Memory.Player;

Board boardAi = new Board();
Board boardAI = new Board();
Menu menu = new Menu("Menu Główne");
menu.Add(new StartGameMenuItem(boardAi, boardAI));
menu.Run();

boardAi.Draw(0);
boardAI.Draw(10);

Human human = new Human();
Computer computer = new Computer(boardAI);
Keyboard keyboard = new Keyboard();
ActionController actionController = new ActionController(human, boardAi, keyboard);

CardManager.Instance.SetRandomModel();

while (true)
{
    computer.DoTurn();

    //Console.SetCursorPosition(human.Position.X, human.Position.Y);

    //var input = Console.ReadKey().Key;

    //keyboard.ButtonPressed(input);

}



