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

        #region Winner      
        public string CheckWinner(Player player)
        {
            string ganador = "";
            (int turn, bool validate) resultado = ValidateCantTurn(2);

            if (resultado.validate == true) 
            { 
                //no necesito que 
                ganador = table.VerifyWinner(player);
            }

            return ganador;
        }
        #endregion

        #region TurnNext
        public bool Play(int row, int column, string player)
        {
            (int turn, bool validate) resultado = ValidateCantTurn(1);

            if (resultado.validate == true)
            {
                resultado.validate = table.AddMovement(row, column, player);
            } 
            return resultado.validate;
        }
        #endregion

        //#region AssignSymbol
        //public bool AssignSymbol(string Symbol, int type)
        //{
        //    bool validar = false;
        //    if (!player.Name.Contains(Symbol))
        //    {
        //        player = new(Symbol, type);
        //        validar = true;
        //    } 
        //    return validar;
        //}
        //#endregion

        #region validateCantTurn
        // valida la cantidad de movimiento , se tienen que hacer dos validaciones distintas
        public (int turn, bool validate) ValidateCantTurn(int condition)
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
