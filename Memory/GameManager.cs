using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class GameManager
    {

        public Board FirstBoard;
        public Board SecondBoard;
        public int Size;
        public Difficulty _difficulty;
        public bool IsPlayer;

        public GameManager()
        {
            _difficulty = Difficulty.Medium;
            Size = 4;
            IsPlayer = false;
        }
        public void StartGame()
        {
            CreatePlayers();
        }

        public void StartMenu()
        {
            Menu Settings = new Menu("Ustawienia", false);
            Settings.Add(new DifficultyOptionMenuItem(this));
            Settings.Add(new ChooseOpponentMenuItem(this));

            Menu menu = new Menu("Menu Główne", true);
            menu.Add(new StartGameMenuItem(this, menu));
            menu.Add(Settings);
            menu.Run();
        }

        public void GameOver(Board winBoard)
        {
            Console.Clear();
            if(winBoard == FirstBoard) 
            {
                Console.WriteLine("Wygrałeś!");
            }
            else
            {
                Console.WriteLine("Wygrał komputer!");
            }
            Thread.Sleep(1000);
            Environment.Exit(0);
        }

        private void CreatePlayers()
        {
            FirstBoard = new Board();
            SecondBoard = new Board();

            Human player = new Human(FirstBoard, 0, 0,true);

            if (IsPlayer)
            {
                Human player02 = new Human(SecondBoard, 10, 10, false);
            }
            else
            {
                Computer computer = new Computer(SecondBoard, 10);
                computer.difficulty = _difficulty;
            }

            DrawBoards(FirstBoard, SecondBoard);
        }

        private void DrawBoards(Board firstBoard, Board secondBoard)
        {
            firstBoard.size = Size;
            secondBoard.size = Size;

            firstBoard.Draw(0);
            CardManager.Instance.SetRandomModel();
            secondBoard.Draw(10);
            CardManager.Instance.SetRandomModel();
        }
    }

    
}
