using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussineTateti.Models
{
    internal class Player
    {
        public string Token { get; set; }

        public Player( string token )
        {
            this.Token = token;
        } 
    }
}
