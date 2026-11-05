using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace BlackJackGrupp
{
    public class Highscore
    {
        public string Name { get; set; }
        public decimal FinalBalance { get; set; }
        public int RoundsPlayed { get; set; }
    }
}
