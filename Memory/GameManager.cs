using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class GameManager
    {

        public Board firstBoard;
        public Board secondBoard;
        public int Size;
        public Difficulty difficulty;
        public bool IsPlayer;

        public GameManager()
        {
            difficulty = Difficulty.Medium;
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
            if(winBoard == firstBoard) 
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
            firstBoard = new Board();
            secondBoard = new Board();

            Human player = new Human(firstBoard, 0, 0,true);

            if (IsPlayer)
            {
                Human player02 = new Human(secondBoard, 10, 10, false);
            }
            else
            {
                Computer computer = new Computer(secondBoard, 10);
                computer.difficulty = difficulty;
            }

            DrawBoards(firstBoard, secondBoard);
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
