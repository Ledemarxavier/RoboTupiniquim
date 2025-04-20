using RoboTupiniquim.ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboTupiniqim.ConsoleApp
{
    public class Controlador
    {
        public void Executar()
        {
            Console.WriteLine(" ______________________________ ");
            Console.WriteLine("|       _______________        |");
            Console.WriteLine("|       ROBÔ TUPINIQUIM        |");
            Console.WriteLine("|______________________________|");

            Console.WriteLine("Digite as coordenadas do terreno (Ex: 5 5):");
            string[] tamanho = Console.ReadLine().Split(' ');
            Terreno terreno = new Terreno(int.Parse(tamanho[0]), int.Parse(tamanho[1]));
            Console.WriteLine("\nSaída:");
            foreach (var t in tamanho)
            {
                Console.WriteLine(t);
            }
            Console.ReadLine();
        }
    }
}