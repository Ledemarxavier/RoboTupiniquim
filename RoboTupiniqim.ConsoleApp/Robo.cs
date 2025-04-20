using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboTupiniquim.ConsoleApp
{
    public class Robo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Direcao { get; private set; }
        public Terreno terreno;

        public Robo(int x, int y, char direcao, Terreno terreno)
        {
            X = x;
            Y = y;
            Direcao = char.ToUpper(direcao);
            this.terreno = terreno;
        }
    }
}