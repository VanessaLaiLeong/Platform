using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plat5
{
    internal class GameLives
    {
        public int lives
        {
            get; set;
        }

        public GameLives(int startingLives)
        {
            lives= startingLives;
        }

        public void decrementLives()
        {
            lives-=1;
        }
    }
}
