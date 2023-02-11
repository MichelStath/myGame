using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myGame
{
    [Serializable]
    class Player
    {
        internal String UserName { get; set; }
        internal int HighScore { get; set; }
        internal Player(string uname, int hscore)
        {
            UserName = uname;
            HighScore = hscore;
        }
    }
}
