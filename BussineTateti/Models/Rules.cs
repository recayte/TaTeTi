using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussineTateti.Models
{
    class Rules
    {
        public Player player { get; set; }
        public Table table { get; set; }

        // conecta entre jugador y tablero 
        public Rules(Player IPlayer, Table ITable)
        {
            this.player = IPlayer;
            this.table = ITable;
        }

        #region Winner
        public string Winner(string player)
        {
            string ganador = "";
            (int turn, bool validate) resultado = validateCantTurn(2);

            if (resultado.validate == true) 
            { 
                ganador = table.VerifyWinner(player);
            }

            return ganador;
        }
        #endregion

        #region TurnNext
        public bool TurnNext(int row, int column, string player)
        {
            (int turn, bool validate) resultado = validateCantTurn(1);

            if (resultado.validate == true)
            {
                resultado.validate = table.AddMovement(row, column, player);
            } 
            return resultado.validate;
        }
        #endregion

        #region AssignSymbol
        public void AssignSymbol(string Symbol, int type)
        {
            Player player = new(Symbol, type);
        }
        #endregion

        #region validateCantTurn
        // valida la cantidad de movimiento 
        public (int turn, bool validate) validateCantTurn(int condition)
        {

            bool validate = true;
            int turn = table.GetTurn();

            //Si la condicion es 1 entonces solo se valida que el turno sea menor
            //Si la condicion es 2 entonces se valida que el turno este entre 5 a 9 turnos
            if ((turn > 9 && condition == 1) || ((turn > 9 || turn < 4) && condition == 2))
            {
                validate = false;
            }
            return (turn, validate);
        }
        #endregion


    }

}
