using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussineTateti.Models
{
    public class Rules
    {
        private Player player1, player2;
        private Table table;
        private Player playerActive;  
        // 

        // conecta entre jugador y tablero 
        public Rules()
        {
            this.player1 = new Player("X");
            this.player2 = new Player("O");
            this.playerActive = new Player("O");
            this.table = new Table();
        }
         
        #region PlayGame
        public Status PlayGame(int row, int column)
        {             
            Status status = table.ValidateTable(row, column);
            if (status != Status.statusOk)
            {
                return status;
            }
            Player player = GetCurrentPlayer();
            table.AddMovement(row, column, player);
            return table.VerifyWinner(player);
        }
        #endregion

        #region GetCurrentPlayer
        private Player GetCurrentPlayer()
        {
          Player player = playerActive;
          if (player.Token == "X")
                player.Token = "O";
          else
                player.Token = "X";
          return player;
        }
        #endregion 

    }

}
