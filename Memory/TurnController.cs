using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class TurnController
    {
        private Player[] players;
        private int index = 0;

        private static TurnController? instance = null;
        public static TurnController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TurnController();
                }

                return instance;
            }
        }

        public TurnController()
        {
            players = new Player[2];
        }

        public void AddPlayers(Player player)
        {
            players[index] = player;
            index++;
        }

        public void ChangePlayer()
        {
            foreach (Player player in players)
            {
                player.isPlaying = !player.isPlaying;
            }
        }

        public void PlayTurn()
        {
            foreach (Player player in players)
            {
                player.DoTurn();
            }
        }

    }
}
