using Memory;
using System.Security.Cryptography;
using static Memory.Player;

GameManager gameManager = new GameManager();

gameManager.StartMenu();
gameManager.StartGame();

while (true)
{
    TurnController.Instance.PlayTurn();
    
    if(gameManager.FirstBoard.points == gameManager.FirstBoard.totalPoints)
    {
        gameManager.GameOver(gameManager.FirstBoard);
    }else if(gameManager.SecondBoard.points == gameManager.SecondBoard.totalPoints)
    {
        gameManager.GameOver(gameManager.SecondBoard);
    }
}



