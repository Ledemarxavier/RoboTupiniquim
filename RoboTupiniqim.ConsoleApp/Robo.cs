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
        public int direcao { get; private set; }
        public Terreno terreno;

        public Robo(int x, int y, char direcaoInicial, Terreno terreno)
        {
            X = x;
            Y = y;

            this.terreno = terreno;
            direcao = ConverteDirecaoInt(char.ToUpper(direcaoInicial));
        }

        public void VirarDireita()
        {
            direcao = (direcao + 1) % 4;
        }

        public void VirarEsquerda()
        {
            direcao = (direcao + 3) % 4;
        }

        public string DirecaoAtual()
        {
            if (direcao == 0) return "N";
            else if (direcao == 1) return "L";
            else if (direcao == 2) return "S";
            else if (direcao == 3) return "O";
            else return DirecaoAtual();
        }

        private int ConverteDirecaoInt(char d)
        {
            if (d == 'N') return 0;
            else if (d == 'L') return 1;
            else if (d == 'S') return 2;
            else if (d == 'O') return 3;
            else return 0;
        }
    }
}