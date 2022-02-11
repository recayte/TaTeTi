using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussineTateti.Models
{
    class Rules
    {
        private Player player1, player2;
        private Table table;

        // conecta entre jugador y tablero 
        public Rules()
        {
            this.player1 = new Player("X");
            this.player2 = new Player("O");
            this.table = new Table();
        }

        #region CheckWinner      
        public string CheckWinner(Player player)
        {
            string winner = "";
            int turn = table.GetTurn();
            if (ValidateTurnMax(turn))
            {
                //no necesito que 
                winner = table.VerifyWinner(player);
            }

            return winner;
        }
        #endregion

        #region Play
        public bool Play(int row, int column, string player)
        {
            int turn = table.GetTurn();
            bool validar = true;

            if (RangeTurn(turn))
            {
                validar = table.AddMovement(row, column, player);
            }
            return validar;
        }
        #endregion

        #region RangeTurn
        public bool RangeTurn(int turn)
        {
            bool validate = true;
            if (turn > 9 || turn < 4) 
            {
                validate = false;
            }
            return validate;
        }
        #endregion

        #region ValidateTurnMax
        public bool ValidateTurnMax(int turn)
        {
            bool validate = true;
            if (turn > 9 )
            {
                validate = false;
            }
            return validate;
        }
        #endregion

       



    }

}
