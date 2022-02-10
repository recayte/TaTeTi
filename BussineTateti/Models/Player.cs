using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussineTateti.Models
{
    class Player
    {
        public string Name { get; init; }
        public int type { get; init; }

        public Player( string name ,int type )
        {
            this.Name = name;
            this.type = type;
        }       

    }
}
