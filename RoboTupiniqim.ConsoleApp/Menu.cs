using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboTupiniquim.ConsoleApp
{
    public class Menu
    {
        private GerenciadorRobo gerenciador = new();

        public void ExibirMenu()
        {
            Console.WriteLine(" ______________________________ ");
            Console.WriteLine("|         ROBÔ TUPINIQUIM      |");
            Console.WriteLine("|                              |");
            Console.WriteLine("|        >>>> MENU <<<<        |");
            Console.WriteLine(" ------------------------------ ");
            Console.WriteLine("1 - Criar/Alterar terreno");
            Console.WriteLine("2 - Adicionar novo robô");
            Console.WriteLine("3 - Enviar comandos para robô");
            Console.WriteLine("4 - Exibir posições dos robôs");
            Console.WriteLine("0 - Encerrar");
        }

        public void OpcaoMenu()
        {
            int opcao;

            do
            {
                ExibirMenu();
                Console.Write("Opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        gerenciador.CriarTerreno();
                        break;

                    case 2:
                        if (gerenciador.terreno == null)
                            Console.WriteLine("Crie o terreno primeiro.");
                        else
                            gerenciador.CriarRobo();
                        break;

                    case 3:
                        if (gerenciador.robos.Count == 0)
                        {
                            Console.WriteLine("Nenhum robô disponível.");
                            break;
                        }

                        for (int i = 0; i < gerenciador.robos.Count; i++)
                            Console.WriteLine($"{i + 1} - Robô em ({gerenciador.robos[i].X}, {gerenciador.robos[i].Y}) {gerenciador.robos[i].DirecaoAtual()}");

                        Console.Write("Escolha o número do robô: ");
                        int indice = int.Parse(Console.ReadLine()) - 1;
                        if (indice < 0 || indice >= gerenciador.robos.Count)
                        {
                            Console.WriteLine("Robô inválido.");
                            break;
                        }
                        Console.Write("Digite os comandos (Ex: EMEEDDMM): ");
                        string comandos = Console.ReadLine().ToUpper();
                        gerenciador.ExecutarComandos(gerenciador.robos[indice], comandos);

                        break;

                    case 4:
                        gerenciador.ExibirPosicoes();
                        break;

                    case 0:
                        Console.WriteLine("Encerrando o programa...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            } while (opcao != 0);
        }
    }
}