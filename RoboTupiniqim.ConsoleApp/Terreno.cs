using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboTupiniquim.ConsoleApp
{
    public class Terreno
    {
        public int MaxX { get; }
        public int MaxY { get; }

        public Terreno(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
        }
    }
}