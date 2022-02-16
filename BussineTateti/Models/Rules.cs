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


        // 

        // conecta entre jugador y tablero 
        public Rules()
        {
            this.player1 = new Player("X");
            this.player2 = new Player("O");
            this.table = new Table();
        }

        #region CheckWinner      
        private string CheckWinner(Player player)
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
        private bool Play(int row, int column, Player player)
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
       
        public string PlayGame(int row, int column )
        {
            string winner= "";
            // comunicar los 5 estados , Inum para devolver los estado 
            // GetGamePlayer() me devuelve el jugador que debe jugar 
            Player player = new Player("asd"); // despues hago la funcion para llamar al jugador
            if (Play(row, column, player))
            {
                winner= CheckWinner(player);              
            }
            
            return winner;
        }

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

         // metodo que llame a agregar movimiento , validar winner



    }

}
