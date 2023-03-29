using Memory;
using System.Security.Cryptography;
using static Memory.Player;

Board board = new Board();
Board boardAI = new Board();

Board[] boards = {board, boardAI};

Menu menu = new Menu("Menu Główne");
menu.Add(new StartGameMenuItem(boards));
menu.Run();

board.Draw(0);
CardManager.Instance.SetRandomModel();
boardAI.Draw(10);
CardManager.Instance.SetRandomModel();

Human human = new Human(board);
Computer computer = new Computer(boardAI, 10);

while (true)
{
    TurnController.Instance.PlayTurn();
}



