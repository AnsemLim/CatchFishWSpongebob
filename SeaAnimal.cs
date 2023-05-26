using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchFishGame
{
    class Declare 
    {
        public int positionX;
        public int positionY;

        public int height;
        public int width;
        public int speedX;
        public int speedY;

        public int limit;
        public int moveLimit;
        public int frames;

        public static Random rand = new Random();

        public bool changeDirection = false;
        public bool isDead = false;
    }
}
