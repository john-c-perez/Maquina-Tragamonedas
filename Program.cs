using System;

namespace Maquina_Tragamonedas
{
    class Program
    {
        private static funcionamiento maquina = new funcionamiento();
        private static int bolsaJugador = 20;
        private static bool seguirJugando = true;

        static void Main(string[] args)
        {
            while (seguirJugando)
            {
                Console.WriteLine("inicias con 20 monedas");
                Console.WriteLine("Bolsa del Jugador: {0} monedas", bolsaJugador);
                Console.WriteLine("¿Jugar una moneda? [s/n]");
                string opcion = Console.ReadLine().ToLower();
                if (opcion.Equals("s"))
                {
                    Console.Clear();
                    bolsaJugador--;
                    Console.WriteLine("Bolsa del Jugador: {0} monedas\n", bolsaJugador);
                    int premio = maquina.JugarMoneda();
                    Console.WriteLine("\nGanas {0} monedas", premio);
                    bolsaJugador += premio;

                    seguirJugando = (maquina.GetBolsa() != 0 && bolsaJugador != 0);

                    Console.WriteLine("Pulse una tecla para seguir...");
                    Console.ReadKey();
                }
                else if (opcion.Equals("n"))
                    seguirJugando = false;

                Console.Clear();
            }

            if (maquina.GetBolsa() == 0) Console.WriteLine("¡La máquina Tragaperras se ha quedado sin monedas!");

            Console.WriteLine("Te vas con {0} monedas en la bolsa", bolsaJugador);
            Console.WriteLine("\t\tFIN DEL JUEGO\n");
        }
    }
}
