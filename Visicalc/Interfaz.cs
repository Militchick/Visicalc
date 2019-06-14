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
        public casilla[,] tabla = new casilla[altura, ancho];

        public void Ejecutar()
        {

            Console.SetWindowSize(120, 30);
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A1");
            Console.ResetColor();
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
                Console.WriteLine("Valor:" + tabla[cuentaltura2, 
                    cuentanchura2].valor);
            }
            while (salidainter != true);

        }

        //Se preparan las tablas, añadiendo
        //los limites de anchura y las anchuras de celdas

        protected void TablasPreparar()
        {
            for (int cuentaltura = 0; 
                cuentaltura < 22; cuentaltura++)
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
                        if(alt > 0)
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(alt);
                        Console.ResetColor();
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
                                    Console.ForegroundColor = 
                                        ConsoleColor.Cyan;
                                    Console.Write(columna);
                                    Console.ResetColor();
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
                                    Console.ForegroundColor = 
                                        ConsoleColor.Cyan;
                                    Console.Write(columna);
                                    Console.ResetColor();
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

            if(cuentaltura2 < 10)
            {
                Console.SetCursorPosition(6 + (11 * cuentanchura2),
                    3 + cuentaltura2);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("         ");
                Console.SetCursorPosition(6 + (11 * cuentanchura2),
                    3 + cuentaltura2);
            }
            else
            {
                Console.SetCursorPosition(7 + (11 * cuentanchura2),
                    3 + cuentaltura2);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("         ");
                Console.SetCursorPosition(7 + (11 * cuentanchura2),
                    3 + cuentaltura2);
            }

            ConsoleKeyInfo TeclaLeida = Console.ReadKey();

            if (TeclaLeida.Key == ConsoleKey.DownArrow)
            {
                if(cuentaltura2 < 21)
                {
                    cuentaltura2++;
                }

                Console.ResetColor();
            }
            else if (TeclaLeida.Key == ConsoleKey.UpArrow)
            {
                if (cuentaltura2 > 1)
                {
                    cuentaltura2--;
                }

                Console.ResetColor();
            }
            else if (TeclaLeida.Key == ConsoleKey.LeftArrow)
            {
                if (cuentanchura2 > 0)
                {
                    cuentanchura2--;
                }

                Console.ResetColor();
            }
            else if (TeclaLeida.Key == ConsoleKey.RightArrow)
            {
                if (cuentanchura2 < 8)
                {
                    cuentanchura2++;
                }

                Console.ResetColor();
            }
            else if (TeclaLeida.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                salidainter = true;

                Console.ResetColor();
            }
            else if ((TeclaLeida.Key == ConsoleKey.D0)
                || (TeclaLeida.Key == ConsoleKey.D1)
                || (TeclaLeida.Key == ConsoleKey.D2)
                || (TeclaLeida.Key == ConsoleKey.D3)
                || (TeclaLeida.Key == ConsoleKey.D4)
                || (TeclaLeida.Key == ConsoleKey.D5)
                || (TeclaLeida.Key == ConsoleKey.D6)
                || (TeclaLeida.Key == ConsoleKey.D7)
                || (TeclaLeida.Key == ConsoleKey.D8)
                || (TeclaLeida.Key == ConsoleKey.D9))
            {
                IntroduceValor(TeclaLeida);
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
            
            Console.ResetColor();
            Console.Clear();
            Pausa(100);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write(letras);
            Console.WriteLine(cuentaltura2);

            Console.ResetColor();

            //Segunda y Tercera Linea Vacias
            Console.WriteLine();
            Console.WriteLine();
            
            /*
            if ((TeclaPulsada(TECLA_INT)) || (TeclaPulsada(TECLA_ESP)))
            {

            }
            */

        }

        protected void IntroduceValor(ConsoleKeyInfo PrimerValor)
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            double valorinicial = 0;

            switch (PrimerValor.Key)
            {
                case ConsoleKey.D0: valorinicial = 0; break;
                case ConsoleKey.D1: valorinicial = 1; break;
                case ConsoleKey.D2: valorinicial = 2; break;
                case ConsoleKey.D3: valorinicial = 3; break;
                case ConsoleKey.D4: valorinicial = 4; break;
                case ConsoleKey.D5: valorinicial = 5; break;
                case ConsoleKey.D6: valorinicial = 6; break;
                case ConsoleKey.D7: valorinicial = 7; break;
                case ConsoleKey.D8: valorinicial = 8; break;
                case ConsoleKey.D9: valorinicial = 9; break;
            }

            tabla[cuentaltura2, cuentanchura2].valor = valorinicial;

            //He usado ReadLine asi que, 
            //guardar el valor tras pulsar las flechas
            //Es imposible
            string valorfinal = Console.ReadLine();

            if (valorfinal != null)
            {
                try
                {
                    double valorfinaldoble = Convert.ToInt32(valorfinal);
                    valorfinaldoble = double.Parse(valorinicial.ToString()
                        + valorfinaldoble.ToString());

                    string cortara9 = Convert.ToString(valorfinaldoble);
                    //int contadora9 = 0;
                    double cortado = 0;

                    if(cortara9.Length < 10)
                    {
                        cortado = double.Parse(cortara9.ToString());
                    }

                    tabla[cuentaltura2, cuentanchura2].valor = cortado;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.ResetColor();
            }

        }
    }
}
