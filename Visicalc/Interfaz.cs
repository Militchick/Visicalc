using System;
using System.Threading;

namespace Visicalc
{
    class Interfaz
    {
        protected bool salidainter = false;

        protected const int altura = 25;
        protected const int ancho = 80;
        protected int cuentaltura2 = 0;
        protected int cuentanchura2 = 0;

        public void ejecutar()
        {

            string[,] tabla = new string[altura, ancho];

            Console.WriteLine("A0");
            Console.WriteLine();
            Console.WriteLine();

            tablas();

            do
            {
                cambiacursor();
                tablas();

                Console.WriteLine();
                Console.WriteLine("Pulsa ESC para salir de la Interfaz");
            }
            while (salidainter != true);

        }

        void tablas()
        {
            for (int cuentaltura = 0; 
                cuentaltura < altura - 4; cuentaltura++)
            {
                for (int cuentanchura = 0;
                    cuentanchura < ancho; cuentanchura++)
                {
                    const byte anchoprimeracelda = 4;
                    const byte anchocelda = 9;

                    if (cuentanchura == 8)
                    {
                        creatablas(cuentaltura, cuentanchura,
                            anchoprimeracelda, anchocelda);
                    }

                    if (salidainter == true)
                    {
                        cuentaltura = altura;
                        cuentanchura = ancho;
                    }
                    else if (cuentanchura >= 8)
                    {
                        cuentaltura = altura;
                        cuentanchura = ancho;
                    }

                }
            }
        }

        public static void Pausa(int milisegundos)
        {
            Thread.Sleep(milisegundos);
        }

        void creatablas(int cuentaltura, int cuentanchura,
            int anchoprimeracelda, int anchocelda)
        {

            char columna = 'A';
            
            for (int alt = 0; alt < cuentanchura; alt++)
            {
                for (byte i = 0; i < anchoprimeracelda; i++)
                {
                    if (i == 0)
                    {
                        Console.Write(alt);
                    }
                    else
                    {

                        Console.Write("_");
                    }
                }

                Console.Write("||");


                for (int i = 0; i < cuentanchura; i++)
                {
                    if (alt == 0)
                    {
                        for (byte j = 0; j < anchocelda-1; j++)
                        {
                            if (j == (anchocelda - 1) / 2)
                            {
                                if ((columna >= 'A') && (columna <= 'H'))
                                {
                                    Console.Write(columna);
                                    columna++;
                                }/*
                                else
                                {
                                    columna = 'A';
                                    Console.Write(columna);
                                }*/
                            }

                            Console.Write("_");
                        }

                        Console.Write("||");
                    }
                    else
                    {
                        for (byte j = 0; j < anchocelda; j++)
                        {
                            if ((alt == 0) && (j == (anchocelda - 1) / 2))
                            {
                                if ((columna >= 'A') && (columna <= 'H'))
                                {

                                    Console.Write(columna);
                                    columna++;
                                }/*
                                else
                                {
                                    columna = 'A';
                                    Console.Write(columna);
                                }*/

                            }

                            Console.Write("_");
                        }

                        Console.Write("||");
                    }
                }
                Console.WriteLine();
            }
        }
          
        
        void cambiacursor()
        {

            Console.WriteLine();

            //const int TECLA_INT = Sdl.SDLK_KP_ENTER;
            //const int TECLA_ESP = Sdl.SDLK_SPACE;
            
            string letras = string.Empty;
            
            //Segunda y Tercera Linea Vacias

            Console.WriteLine();
            Console.WriteLine();

            ConsoleKeyInfo TeclaLeida = Console.ReadKey();

            if (TeclaLeida.Key == ConsoleKey.DownArrow)
            {
                if(cuentaltura2 < 21)
                {
                    cuentaltura2++;
                }
            }
            else if (TeclaLeida.Key == ConsoleKey.UpArrow)
            {
                if (cuentaltura2 > 0)
                {
                    cuentaltura2--;
                }
            }
            else if (TeclaLeida.Key == ConsoleKey.LeftArrow)
            {
                if (cuentanchura2 > 0)
                {
                    cuentanchura2--;
                }
            }
            else if (TeclaLeida.Key == ConsoleKey.RightArrow)
            {
                if (cuentanchura2 < 8)
                {
                    cuentanchura2++;
                }
            }
            else if (TeclaLeida.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                salidainter = true;
            }

            char primeraletra = 'A';

            for (int i = 0; i < cuentanchura2; i++)
            {
                if ((primeraletra >= 'A') && (primeraletra < 'H'))
                {
                    primeraletra++;
                }/*
                else
                {
                    primeraletra = 'A';
                    letras += primeraletra;
                }*/
            }

            letras += primeraletra;

            Console.Clear();
            Pausa(100);

            Console.Write(letras);
            Console.WriteLine(cuentaltura2);
            
            Console.WriteLine();
            Console.WriteLine();
            
            /*
            if ((TeclaPulsada(TECLA_INT)) || (TeclaPulsada(TECLA_ESP)))
            {

            }
            */

        }
    }
}
