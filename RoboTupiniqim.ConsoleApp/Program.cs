namespace RoboTupiniqim.ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)

        {
            while (true)
            {
                Controlador controlador = new Controlador();
                controlador.Executar();
                Console.ReadLine();
            }
        }
    }
}