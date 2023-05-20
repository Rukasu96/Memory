using Memory;
using System.Security.Cryptography;
using static Memory.Player;

int count = 0;
new Thread(() =>
{
    while(true)
    {
        var pos = Console.GetCursorPosition();
        Console.SetCursorPosition(0, 5);
        Console.Write($"{count / 60}:{count % 60}");
        Console.SetCursorPosition(pos.Left, pos.Top);
        count++;
        Thread.Sleep(1000);
    }

}).Start(); 

GameManager gameManager = new GameManager();

gameManager.StartMenu();
gameManager.StartGame();

while (true)
{
    TurnController.Instance.PlayTurn();
    
    if(gameManager.firstBoard.points == gameManager.firstBoard.totalPoints)
    {
        gameManager.GameOver(gameManager.firstBoard);
    }else if(gameManager.secondBoard.points == gameManager.secondBoard.totalPoints)
    {
        gameManager.GameOver(gameManager.secondBoard);
    }
}



