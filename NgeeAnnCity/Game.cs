using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgeeAnnCity
{
    class Game
    {
        public int MaxRow { get; set; }
        public string PlayerName { get; set; }

        public int PlayerScore { get; set; }

        public char[,] PlayerBoard { get; set; }
        public int Coins { get; set; }

        public int Turn { get; set; }

    }
}
