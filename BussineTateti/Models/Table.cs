using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussineTateti.Models
{
    public class Table
    { 
        // privadas en en miniusculas
        // funciones bloqueada , fuera de rango , si esta lleno 
        private string[,] tableTaTeTi = new string[3, 3]; 
        private readonly Status _status;

        public Table()
        {
            _status = new Status();
        }               

        #region AddMovement
        public void AddMovement(int row, int column, Player player)
        { 
           tableTaTeTi[row, column] = player.Token;                            
        }
        #endregion

        #region WrongPosition
        private Status WrongPosition(int row, int column)
        { 
           if (tableTaTeTi[row, column] != null)
           {
                return Status.wrongPosition;
           }
           return Status.statusOk;
        }
        #endregion

        #region IsfullMatrix
        private Status IsfullMatrix()
        { 
            for (int fila = 0; fila < 3; fila++)
            {
                if (tableTaTeTi[fila, 0] == null || tableTaTeTi[fila, 1] == null || tableTaTeTi[fila, 2]  == null)
                {
                    return Status.statusOk;
                }
            }
            return  Status.fullMatrix;
        }
        #endregion

        #region 
        private Status IndexOutOfRangeException(int row, int column)
        {
            if (row >= 3 || column >= 3 || row < -1 || column < -1)
                return Status.IndexOutOfRangeException;
            return Status.statusOk;
        }
        #endregion

        #region ValidateTable
        public Status ValidateTable(int row, int column)
        {
            Status status;
            status = IndexOutOfRangeException(row, column);

            if (status == Status.statusOk)
                status = IsfullMatrix();
            if (status == Status.statusOk)
                status = WrongPosition(row, column);

            return status;
        }
        #endregion

        #region VerifyVerticals
        private bool VerifyVerticals(Player player)
        {
            for (int fila = 0; fila < 3; fila++)
            {
                if (tableTaTeTi[0, fila] == player.Token && tableTaTeTi[0, fila] == tableTaTeTi[1, fila] && tableTaTeTi[1, fila] == tableTaTeTi[2, fila])
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region VerifyHorizontals
        private bool VerifyHorizontals(Player player)
        {
           for (int fila = 0; fila < 3; fila++)
            {
                if (tableTaTeTi[fila, 0] == player.Token && tableTaTeTi[fila, 0] == tableTaTeTi[fila, 1] && tableTaTeTi[fila, 1] == tableTaTeTi[fila, 2])
                {
                    return true;
                }
            }
            return false;
        }
        #endregion 

        #region VerifyDiagonal
        private bool VerifyDiagonal(Player player)
        {
            if (tableTaTeTi[0, 0] == player.Token && tableTaTeTi[0, 0] == tableTaTeTi[1, 1] && tableTaTeTi[1, 1] == tableTaTeTi[2, 2])
            {
                return true;
            }
            else if (tableTaTeTi[2, 0] == player.Token && tableTaTeTi[2, 0] == tableTaTeTi[1, 1] && tableTaTeTi[1, 1] == tableTaTeTi[0, 2])
            {
                return true;
            }

            return false;
        }
        #endregion

        #region VerifyWinner
        //no deberia pasar el jugador 
        public Status VerifyWinner(Player player)
        {
            bool winner=false; 
            winner = VerifyVerticals(player);
            if (!winner)
                winner = VerifyHorizontals(player);
            if (!winner)
                 winner = VerifyDiagonal(player);
            if (winner == true) 
                return Status.winner;

            return Status.statusOk;
        }
        #endregion

        #region ResettableTaTeTi
        public void ResettableTaTeTi()
        {
            for (int fila = 0; fila < 3; fila++)
                for (int columna = 0; columna < 3; columna++)
                    tableTaTeTi[fila, columna] = "";           
        }
        #endregion 

    }
}
