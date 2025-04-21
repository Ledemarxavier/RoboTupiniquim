using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboTupiniquim.ConsoleApp
{
    internal class GerenciadorRobo
    {
        public List<Robo> robos { get; set; } = new();
        public Terreno terreno;

        public void CriarTerreno()
        {
            Console.Clear();
            Console.WriteLine("\nDigite as coordenadas do terreno (Ex: 5 5):");
            string[] tamanho = Console.ReadLine().Split(' ');
            int x = int.Parse(tamanho[0]);
            int y = int.Parse(tamanho[1]);
            terreno = new Terreno(x, y);
        }

        public Robo CriarRobo()
        {
            Console.Clear();
            while (true)
            {
                Console.Write("Digite a posição inicial (X Y Direção): ");
                string[] posicao = Console.ReadLine().Split(' ');

                int x, y;
                char direcao;

                if (posicao.Length != 3)
                {
                    Console.WriteLine("Formato inválido. Digite no formato: X Y Direção (ex: 1 2 N)");
                    continue;
                }

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
                bool ocupado = robos.Exists(r => r.X == x && r.Y == y);
                if (ocupado)
                {
                    Console.WriteLine("Já existe um robô nessa posição. Escolha outra.");
                    continue;
                }
                Console.Clear();
                Robo robo = new Robo(x, y, direcao, terreno);
                robos.Add(robo);
                Console.WriteLine($"Robô criado : {robo.X} {robo.Y} {robo.DirecaoAtual()}");
                Console.WriteLine("\nAperte ENTER para continuar...");
                Console.ReadLine();
                Console.Clear();
                return robo;
            }
        }

        public void ExecutarComandos(Robo robo, string comandos)
        {
            Console.Clear();
            foreach (char c in comandos)
            {
                if (c == 'E')
                {
                    robo.VirarEsquerda();
                }
                else if (c == 'D')
                {
                    robo.VirarDireita();
                }
                else if (c == 'M')
                {
                    int novoX = robo.X;
                    int novoY = robo.Y;

                    if (robo.direcao == 0) novoY++;
                    else if (robo.direcao == 1) novoX++;
                    else if (robo.direcao == 2) novoY--;
                    else if (robo.direcao == 3) novoX--;

                    bool ocupado = robos.Exists(r => r != robo && r.X == novoX && r.Y == novoY);
                    if (!terreno.PosicaoValida(novoX, novoY))
                    {
                        Console.WriteLine($"Robô tentou sair dos limites: ({novoX},{novoY})");
                    }
                    else if (ocupado)
                    {
                        Console.WriteLine($"Colisão detectada! Outro robô está em ({novoX},{novoY})");
                    }
                    else
                    {
                        robo.X = novoX;
                        robo.Y = novoY;
                    }
                }
            }
            Console.Write("Comando enviado!\n");
            Console.WriteLine("Aperte ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        public void ExibirPosicoes()
        {
            Console.Clear();
            if (robos.Count == 0)
            {
                Console.WriteLine("Nenhum robô cadastrado.");
                return;
            }
            Console.WriteLine("\n---- Posições finais dos robôs ----");
            for (int i = 0; i < robos.Count; i++)
            {
                Robo r = robos[i];
                Console.WriteLine($"Robô #{i + 1}: {r.X} {r.Y} {r.DirecaoAtual()}");
            }
            Console.Write("Aperte ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}