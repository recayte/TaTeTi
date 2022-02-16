using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussineTateti.Models
{
    internal class Table
    {
        //almacenar el ultimo jugador y asignar jugadores por turnos
        private string[,] TableTaTeTi = new string[3, 3];
        private int Turn  { get; set; }
        private string Winner { get; set; }


        #region AddMovement
        public bool AddMovement(int row, int column, Player player)
        {
            bool resultado = false;
            if (TableTaTeTi[row, column] == null)
            {
                TableTaTeTi[row, column] = player.Token;
                Turn += 1;
                resultado = true;
            }            
            return resultado;
        }
        #endregion

      // manejo de jugador 

        #region VerifyVerticals
        private void VerifyVerticals(Player player)
        {
            for (int fila = 0; fila < 3; fila++)
            {
                if (TableTaTeTi[0, fila] == player.Token && TableTaTeTi[0, fila] == TableTaTeTi[1, fila] && TableTaTeTi[1, fila] == TableTaTeTi[2, fila])
                {
                    Winner = player.Token;
                    return;
                }
            }
        }
        #endregion

        #region VerifyHorizontals
        private void VerifyHorizontals(Player player)
        {        
            for (int fila = 0; fila < 3; fila++)
            {
                if (TableTaTeTi[fila, 0] == player.Token && TableTaTeTi[fila, 0] == TableTaTeTi[fila, 1] && TableTaTeTi[fila, 1] == TableTaTeTi[fila, 2])
                {
                    Winner = player.Token;
                    return;
                }
            }
        }
        #endregion 

        #region VerifyDiagonal
        private void VerifyDiagonal(Player player)
        {
            if (TableTaTeTi[0, 0] == player.Token && TableTaTeTi[0, 0] == TableTaTeTi[1, 1] && TableTaTeTi[1, 1] == TableTaTeTi[2, 2])
            {
                Winner = player.Token;
                return;
            }
            else if (TableTaTeTi[2, 0] == player.Token && TableTaTeTi[2, 0] == TableTaTeTi[1, 1] && TableTaTeTi[1, 1] == TableTaTeTi[0, 2])
            {
                Winner = player.Token;
                return;
            }
        }
        #endregion

        #region VerifyWinner
        //no deberia pasar el jugador 
        public string VerifyWinner(Player player)
        {
                VerifyVerticals(player);
            if(Winner == null)
                VerifyHorizontals(player);
            if (Winner == null)
                VerifyDiagonal(player);

            return Winner;
        }
        #endregion

        #region ResetTableTaTeTi
        public void ResetTableTaTeTi()
        {
            for (int fila = 0; fila < 3; fila++)
                for (int columna = 0; columna < 3; columna++)
                    TableTaTeTi[fila, columna] = "";           
        }
        #endregion

        #region GetTurn
        public int GetTurn()
        {
            return Turn;
        }
        #endregion

    }
}
