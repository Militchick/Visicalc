using System;
using System.Threading;

namespace Visicalc
{
    class Interfaz
    {

        protected bool salidainter = false;

        protected const int altura = 25;
        protected const int ancho = 80;
        protected int cuentaltura2 = 1;
        protected int cuentanchura2 = 0;
        
        public void Ejecutar()
        {

            Console.SetWindowSize(120, 30);

            string[,] tabla = new string[altura, ancho];

            Console.WriteLine("A1");
            Console.WriteLine();
            Console.WriteLine();

            TablasPreparar();

            Console.WriteLine();
            Console.WriteLine("Pulsa ESC para salir de la Interfaz");

            do
            {
                CambiarTecla();
                TablasPreparar();

                Console.WriteLine();
                Console.WriteLine("Pulsa ESC para salir de la Interfaz");
            }
            while (salidainter != true);

        }

        //Se preparan las tablas, añadiendo
        //los limites de anchura y las anchuras de celdas

        protected void TablasPreparar()
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
        
        //Sirve para pausar durante un tiempo la consola
        //Usa System.Threading

        public static void Pausa(int milisegundos)
        {
            Thread.Sleep(milisegundos);
        }

        //Aqui se limita las filas (altura) y se dibujan las tablas
        //Incluyendo las letras mientras la altura sea 0 (la primera linea)

        protected void creatablas(int cuentaltura, int cuentanchura,
            int anchoprimeracelda, int anchocelda)
        {

            char columna = 'A';
            
            for (int alt = 0; alt < 22; alt++)
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
          
        //Se usa para ir mostrando en que casilla se esta actualmente
        //En la primera linea de la consola, se comprueba la casilla
        //despues del pulsar un boton
        
        protected void CambiarTecla()
        {

            Console.WriteLine();

            //const int TECLA_INT = Sdl.SDLK_KP_ENTER;
            //const int TECLA_ESP = Sdl.SDLK_SPACE;
            
            string letras = string.Empty;
            

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
                if (cuentaltura2 > 1)
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

            //Segunda y Tercera Linea Vacias
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
