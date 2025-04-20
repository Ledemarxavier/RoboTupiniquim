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
        public List<Robo> robos = new List<Robo>();
        public Terreno terreno;

        public void Executar()
        {
            Console.WriteLine(" ______________________________ ");
            Console.WriteLine("|       _______________        |");
            Console.WriteLine("|       ROBÔ TUPINIQUIM        |");
            Console.WriteLine("|______________________________|");

            CriarTerreno();
            Console.Write("Quantos robôs deseja adicionar? ");
            int quantidade = int.Parse(Console.ReadLine());

            for (int i = 0; i < quantidade; i++)
            {
                Console.WriteLine($"\nConfigurar do robô ->{i + 1}:");
                Robo robo = CriarRobo();
                robos.Add(robo);

                Console.Write("Digite os comandos (Ex: EMEMEMEMM): ");
                string comandos = Console.ReadLine().ToUpper();
            }
            Console.WriteLine("\n---- Posições finais dos robôs ----");
            for (int i = 0; i < robos.Count; i++)
            {
                Robo r = robos[i];
                Console.WriteLine($"Robô #{i + 1}: {r.X} {r.Y}");
            }
        }

        public void CriarTerreno()
        {
            Console.WriteLine("\nDigite as coordenadas do terreno (Ex: 5 5):");
            string[] tamanho = Console.ReadLine().Split(' ');
            int x = int.Parse(tamanho[0]);
            int y = int.Parse(tamanho[1]);
            terreno = new Terreno(x, y);
        }

        public Robo CriarRobo()
        {
            while (true)
            {
                Console.Write("Digite a posição inicial (X Y Direção): ");
                string[] posicao = Console.ReadLine().Split(' ');

                int x, y;
                char direcao;

                if (!int.TryParse(posicao[0], out x) || !int.TryParse(posicao[1], out y) || !char.TryParse(posicao[2], out direcao))
                {
                    Console.WriteLine("Valores inválidos. Use inteiros para X/Y e uma letra para direção.");
                    continue;
                }

                if (!terreno.PosicaoValida(x, y))
                {
                    Console.WriteLine("Posição fora dos limites do terreno. Tente novamente.");
                    continue;
                }

                Robo robo = new Robo(x, y, direcao, terreno);
                Console.WriteLine($"Posição: {robo.X} {robo.Y} {robo.Direcao}");
                return robo;
            }
        }
    }
}