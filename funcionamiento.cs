using System;
using System.Collections.Generic;
using System.Text;

namespace Maquina_Tragamonedas
{
    class funcionamiento
    {
        private int bolsa;
        private int cifra1;
        private int cifra2;
        private int cifra3;

        public funcionamiento()
        {
            bolsa = 100;
            cifra1 = 0;
            cifra2 = 0;
            cifra3 = 0;
        }

        public int GetBolsa() => bolsa;

        public int JugarMoneda()
        {
            bolsa++;
            Random azar = new Random();
            cifra1 = (int)azar.Next(0, 10);
            cifra2 = (int)azar.Next(0, 10);
            cifra3 = (int)azar.Next(0, 10);
            MostrarResultado();
            return AnalizarResultado();
        }

        private void MostrarResultado()
        {
            Console.Write("Números obtenidos: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[{0}] [{1}] [{2}]", cifra1, cifra2, cifra3);
            Console.ResetColor();
        }

        private int AnalizarResultado()
        {
            //Premio GORDO
            if (cifra1 == 7 && cifra2 == 7 && cifra3 == 7)
            {
                int premio = bolsa;
                bolsa = 0;
                return premio;
            }
            //Gana 7 monedas, si hay suficientes
            if (cifra1 == 0 && cifra2 == 0 && cifra3 == 0)
            {
                if (bolsa >= 7)
                {
                    bolsa -= 7;
                    return 7;
                }
                else
                {
                    int premio = bolsa;
                    bolsa = 0;
                    return premio;
                }
            }
            //Tres iguales, tres monedas
            if (cifra1 == cifra2 && cifra1 == cifra3)
            {
                if (bolsa >= 3)
                {
                    bolsa -= 3;
                    return 3;
                }
                else
                {
                    int premio = bolsa;
                    bolsa = 0;
                    return premio;
                }
            }
            //Dos iguales, dos monedas
            if (cifra1 == cifra2 || cifra1 == cifra3 || cifra2 == cifra3)
            {
                if (bolsa >= 2)
                {
                    bolsa -= 2;
                    return 2;
                }
                else
                {
                    int premio = bolsa;
                    bolsa = 0;
                    return premio;
                }
            }
            //No hay premio
            return 0;
        }
    }
}
