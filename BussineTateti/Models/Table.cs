using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussineTateti.Models
{
    class Table
    {
        private string[,] TableTaTeTi = new string[3, 3];
        private int Turn  { get; set; }
        private string Ganador { get; set; }

        #region AddMovement
        public bool AddMovement(int row, int column, string player)
        {
            bool resultado = false;
            if (TableTaTeTi[row, column] == null)
            {
                TableTaTeTi[row, column] = player;
                Turn += 1;
                resultado = true;
            }            
            return resultado;
        }
        #endregion

        #region VerifyVerticals
        public void VerifyVerticals(string player)
        {
            for (int fila = 0; fila < 3; fila++)
            {
                if (TableTaTeTi[0, fila] == player && TableTaTeTi[0, fila] == TableTaTeTi[1, fila] && TableTaTeTi[1, fila] == TableTaTeTi[2, fila])
                {
                    Ganador = player;
                }
            }
        }
        #endregion

        #region VerifyHorizontals
        public void VerifyHorizontals(string player)
        {        
            for (int fila = 0; fila < 3; fila++)
            {
                if (TableTaTeTi[fila, 0] == player && TableTaTeTi[fila, 0] == TableTaTeTi[fila, 1] && TableTaTeTi[fila, 1] == TableTaTeTi[fila, 2])
                {
                    Ganador = player;
                }
            }
        }
        #endregion 

        #region VerifyDiagonal
        public void VerifyDiagonal(string player)
        {
            if (TableTaTeTi[0, 0] == player && TableTaTeTi[0, 0] == TableTaTeTi[1, 1] && TableTaTeTi[1, 1] == TableTaTeTi[2, 2])
            {
                Ganador = player;
            }
            else if (TableTaTeTi[2, 0] == player && TableTaTeTi[2, 0] == TableTaTeTi[1, 1] && TableTaTeTi[1, 1] == TableTaTeTi[0, 2])
            {
                Ganador = player;
            }
        }
        #endregion

        #region VerifyWinner
        public string VerifyWinner(string player)
        {
                VerifyVerticals(player);
            if(Ganador == null)
                VerifyHorizontals(player);
            if (Ganador == null)
                VerifyDiagonal(player);

            return Ganador;
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
