using RoboTupiniquim.ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RoboTupiniqim.ConsoleApp
{
    public class Controlador
    {
        private Menu menu = new();

        public void Executar()
        {
            menu.OpcaoMenu();
        }
    }
}